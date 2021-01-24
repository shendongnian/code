c#
namespace NHibernateFetchJoinTest2
{
    using System;
    using NHibernateFetchJoinTest2.DomainMapping;
    using NHibernateFetchJoinTest2.Domains;
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var session = Mapper.SessionFactory.OpenSession())
            {
                Console.WriteLine("SQL produced: ");
                var d = session.Get<Document>(1);
                Console.ReadLine();
                //Console.WriteLine("Document's periods: ");
                //foreach (var period in d.Periods)
                //{
                //    Console.WriteLine($"* {period.PeriodDescription}");
                //}
                Console.ReadLine();
            }
        }
    }
}
Produces this:
SQL produced: 
NHibernate:  
    SELECT
        document0_.Id as id1_0_1_,
        document0_.DocumentDescription as documentdescription2_0_1_,
        periods1_.DocumentId as documentid3_1_3_,
        periods1_.Id as id1_1_3_,
        periods1_.Id as id1_1_0_,
        periods1_.PeriodDescription as perioddescription2_1_0_ 
    FROM
        Document document0_ 
    left outer join
        Period periods1_ 
            on document0_.Id=periods1_.DocumentId 
    WHERE
        document0_.Id=@p0;
    @p0 = 1 [Type: Int32 (0:0:0)]
Your mappings resemble the following. Your child collection `Lazy`-loading is set to `Lazy` (as opposed to `NoLazy`), yet its `Fetch` strategy is set to `Join`. To wit:
c#
namespace NHibernateFetchJoinTest2.DomainMapping.Mappings
{
    using NHibernate.Mapping.ByCode.Conformist;
    using NHibernateFetchJoinTest2.Domains;
    public class DocumentMapping : ClassMapping<Document>
    {
        public DocumentMapping()
        {
            Id(x => x.Id);
            Property(x => x.DocumentDescription);
            Bag(x => x.Periods, collectionMapping =>
            {
                collectionMapping.Inverse(true);
                collectionMapping.Key(k => k.Column("DocumentId"));
                collectionMapping.Lazy(NHibernate.Mapping.ByCode.CollectionLazy.Lazy);
                // Remove this. This causes Document's Periods to load, 
                // even if child collection Periods is not accessed yet.
                // This is evident in SQL log, it shows LEFT JOIN Period.
                collectionMapping.Fetch(NHibernate.Mapping.ByCode.CollectionFetchMode.Join);
            }, mapping => mapping.OneToMany());
        }
    }
    public class PeriodMapping: ClassMapping<Period>
    {
        public PeriodMapping()
        {
            Id(x => x.Id);
            Property(x => x.PeriodDescription);
        }
    }
}
If this is removed... 
c#
collectionMapping.Fetch(NHibernate.Mapping.ByCode.CollectionFetchMode.Join);
...child collection Periods is not prematurely-fetched by its parent (Document):
sql
SQL produced: 
NHibernate: 
    SELECT
        document0_.Id as id1_0_0_,
        document0_.DocumentDescription as documentdescription2_0_0_ 
    FROM
        Document document0_ 
    WHERE
        document0_.Id=@p0;
    @p0 = 1 [Type: Int32 (0:0:0)]
Repro steps used: https://github.com/MichaelBuen/NHibernateFetchJoinTest2
