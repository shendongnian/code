csharp
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class User : Entity
        {
            public string Email { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var user = new User { Email = "Email@Domain.Com" };
            user.Save();
            DB.Update<User>()
              .Match(u => u.ID == user.ID)
              .WithPipelineStage("{ $set: { LowerCaseEmail: { $toLower: '$Email' } } }")
              .WithPipelineStage("{ $unset: 'Email'}") //if you need to remove the original field
              .ExecutePipeline();
        }
    }
}
