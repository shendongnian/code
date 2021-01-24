csharp
using MongoDB.Entities;
using System;
using System.Collections.Generic;
namespace StackOverflow
{
    public class Program
    {
        public class MySample : Entity
        {
            public DateTime TimeStamp { get; set; }
        }
        public class Sample1 : MySample
        {
            public string SomeProp { get; set; }
        }
        public class Sample2 : MySample
        {
            public string AnotherProp { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var sample1 = new Sample1 { SomeProp = "some prop value", TimeStamp = DateTime.UtcNow };
            var sample2 = new Sample2 { AnotherProp = "another prop", TimeStamp = DateTime.UtcNow };
            DB.Save(sample1);
            DB.Save(sample2);
            var s1 = FindSamples<Sample1>();
            var s2 = FindSamples<Sample2>();
            List<T> FindSamples<T>() where T : MySample
            {
                return DB.Find<T>()
                         .Many(s =>
                               s.TimeStamp >= DateTime.UtcNow.AddMinutes(-1) &&
                               s.TimeStamp <= DateTime.UtcNow.AddMinutes(1));
            }
        }
    }
}
