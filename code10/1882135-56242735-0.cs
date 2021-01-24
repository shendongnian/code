using MongoDB.Entities;
namespace StackOverflow
{
    public class RequestAccess : Entity
    {
        public bool IsClosed { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("test");
            var result = CloseRequest("xxxxxxx");
        }
        public static RequestAccess CloseRequest(string requestId)
        {
            DB.Update<RequestAccess>()
              .Match(x => x.ID == requestId)
              .Set(x => x.IsClosed, true)
              .Execute();
            return DB.Find<RequestAccess>(requestId);
        }
    }
}
i think the code is self explanatory. if you need further clarification, let me know. good luck!
