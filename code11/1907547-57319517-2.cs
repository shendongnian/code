    using MongoDB.Entities; // PM> Install-Package MongoDB.Entities
    using System.Linq;
    using System.Threading.Tasks;
    namespace StackOverflow
    {
        public class Document : Entity
        {
            public SubDocument[] SubDocs { get; set; } = new SubDocument[] { };
        }
        public class SubDocument
        {
            public int Count { get; set; }
            public string Name { get; set; }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test");
                var doc = new Document();
                doc.Save();
                var subDoc = new SubDocument { Name = "iron man" };
                Parallel.ForEach(Enumerable.Range(1, 20), _ =>
                 {
                     DB.Update<Document>()
                       .Match(d =>
                              d.ID == doc.ID &&
                              !d.SubDocs.Any(s => s.Name == subDoc.Name))
                       .Modify(b => b.Push(d => d.SubDocs, subDoc))
                       .Execute();
                     DB.Update<Document>()
                       .Match(d =>
                              d.ID == doc.ID &&
                              d.SubDocs.Any(s => s.Name == subDoc.Name))
                       .Modify(b =>
                               b.Inc(d => d.SubDocs[-1].Count, 1))
                       .Execute();
                 });
            }
        }
    }
