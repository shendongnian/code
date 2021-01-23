    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using FluentNHibernate.Mapping;
    
    namespace NhOneToOne
    {
        public class Program
        {
            static void Main(string[] args)
            {
                try
                {
    
                    var sessionFactory = Fluently.Configure()
                                                 .Database(
                                                        MsSqlConfiguration.MsSql2005
                                                                          .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NHTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                                                                          .ShowSql()
                                                  )
                                                 .Mappings(m => m
                                                 .FluentMappings.AddFromAssemblyOf<Program>())
                                                 .BuildSessionFactory();
    
                    ISession session = sessionFactory.OpenSession();
                    
    
                    Parent parent = new Parent();
                    parent.Name = "test";
                    Child child = new Child();
                    child.Parent = parent;
                    parent.Child = child;
                    session.Save(parent);
                    session.Save(child);
    
                    int id = parent.Id;
                    session.Clear();
                    parent = session.Get<Parent>(id);
                    child = parent.Child;
    
     
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
    
        }
    
        public class Child
        {
            public virtual string Name { get; set; }
            public virtual int Id { get; set; }
    
            public virtual Parent Parent { get; set; }
        }
    
        public class Parent
        {
            public virtual string Name { get; set; }
            public virtual int Id { get; set; }
    
            public virtual Child Child { get; set; }
    
        }
    
        public class ChildMap : ClassMap<Child>
        {
            public ChildMap()
            {
                Table("ChildTable");
                Id(x => x.Id).GeneratedBy.Native();
                Map(x => x.Name);
    
                References(x => x.Parent).Column("IdParent");
    
            }
        }
    
        public class ParentMap : ClassMap<Parent>
        {
            public ParentMap()
            {
                Table("ParentTable");
                Id(x => x.Id).GeneratedBy.Native();
                Map(x => x.Name);
    
                HasOne(x => x.Child).PropertyRef(nameof(Child.Parent));
            }
    
        }
    }
