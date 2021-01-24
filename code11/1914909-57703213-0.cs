csharp
using MongoDB.Entities;
using System;
using System.Collections.Generic;
namespace StackOverflow
{
    public class Program
    {
        public class Member : Entity
        {
            public string Sid { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var members = new List<Member>();
            for (int i = 1; i <= 10; i++)
            {
                members.Add(new Member
                {
                    Sid = Guid.NewGuid().ToString()
                });
            }
            members.Save();
            DB.Update<Member>()
              .Match(_ => true)
              .WithPipelineStage("{ '$set': { 'Sids': ['$Sid'] } }")
              .WithPipelineStage("{ '$unset': ['Sid'] }")
              .ExecutePipeline();
        }
    }
}
