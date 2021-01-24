csharp
using MongoDB.Entities;
using System;
namespace StackOverflow
{
    public class Team : Entity
    {
        public DateTime DisbandedTime { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            DB.Update<Team>()
              .Match(t => t.ID == "xxxxxxxxxxx")
              .Modify(t => t.DisbandedTime, DateTime.Now)
              .Execute();
            
            //builder method alternative
            DB.Update<Team>()
              .Match(t => t.ID == "xxxxxxxxxxx")
              .Modify(b => b.CurrentDate(t => t.DisbandedTime))
              .Execute();
        }
    }
}
