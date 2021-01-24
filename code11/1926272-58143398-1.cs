csharp
using MongoDB.Entities;
using System;
namespace StackOverflow
{
    public class Disclaimer : Entity
    {
        public Override[] Overrides { get; set; }
    }
    public class Override
    {
        public int CategoryId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Message { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            // create seed data
            var seed = new Disclaimer
            {
                Overrides = new[]
                {
                    new Override
                    {
                        CategoryId = 666, EffectiveDate = DateTime.Now.AddDays(-1), Message = "disclaimer 1"
                    },
                    new Override
                    {
                        CategoryId = 666, EffectiveDate = DateTime.Now.AddDays(-1), Message = "disclaimer 2"
                    },
                    new Override
                    {
                        CategoryId = 777, EffectiveDate = DateTime.Now.AddDays(-1), Message = "disclaimer 3"
                    }
                }
            }; seed.Save();
            // start bulk update command
            DB.Update<Disclaimer>()
              // step1: set expiry date on existing 666s
              .Match(d => d.ID == seed.ID)
              .WithArrayFilter("{ 'x.CategoryId' : 666 }")
              .Modify(b => b.Set("Overrides.$[x].ExpiryDate", DateTime.Now))
              .AddToQueue()
              // step2: add a new 666
              .Match(d => d.ID == seed.ID)
              .Modify(b => b.Push(d => d.Overrides,
                                         new Override
                                         {
                                             CategoryId = 666,
                                             EffectiveDate = DateTime.Now,
                                             Message = "disclaimer 4"
                                         }))
              .AddToQueue()
              // run two step bulk update command
              .Execute();
        }
    }
}
