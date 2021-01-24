csharp
using MongoDB.Entities;
using MongoDB.Entities.Core;
using System;
using System.Linq;
namespace StackOverflow
{
    public class TeeBee : Entity
    {
        public int code { get; set; }
        public DateTime create_Date { get; set; }
        public string guid { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            (new[] {
                new TeeBee { code = 0, create_Date = DateTime.UtcNow, guid = "xxx"},
                new TeeBee { code = 0, create_Date = DateTime.UtcNow, guid = "xxx"},
                new TeeBee { code = 0, create_Date = DateTime.UtcNow, guid = "yyy"},
                new TeeBee { code = 1, create_Date = DateTime.UtcNow, guid = "xxx"},
            }).Save();
            var result = DB.Queryable<TeeBee>() // for official driver use: collection.AsQueryable()
                           .Where(tb =>
                                  tb.code == 0 &&
                                  tb.create_Date <= DateTime.UtcNow.AddDays(1) &&
                                  tb.create_Date >= DateTime.UtcNow.AddDays(-1))
                           .GroupBy(tb => tb.guid,
                                   (g, tbs) => new
                                   {
                                       tbs.First().code,
                                       tbs.First().create_Date,
                                       uniqueGuids = tbs.Select(tb => tb.guid).Distinct()
                                   })
                           .Select(x => new
                           {
                               Code = x.code,
                               DateStr = x.create_Date.DayOfYear,
                               Count = x.uniqueGuids.Count()
                           })
                           .ToList();
        }
    }
}
