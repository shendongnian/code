csharp
using MongoDB.Entities;
using System;
namespace StackOverflow
{
    public class Program
    {
        public class Conversation : Entity
        {
            public DateTime LastSent { get; set; }
            public Message[] Messages { get; set; }
        }
        public class Message
        {
            public string Content { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var convo = new Conversation
            {
                LastSent = DateTime.Now.AddMinutes(-10),
                Messages = new[] { new Message { Content = "This is the first message..." } }
            };
            convo.Save();
            var msg = new Message { Content = "This is a new message..." };
            DB.Update<Conversation>()
              .Match(c => c.ID == convo.ID)
              .Modify(c => c.LastSent, DateTime.Now)
              .Modify(b => b.Push(c => c.Messages, msg))
              .Execute();
        }
    }
}
the following update command is sent to the database:
java
db.Conversation.update(
    {
        "_id": ObjectId("5d0ce23647e2d210903b3930")
    },
    {
        "$set": {
            "LastSent": ISODate("2019-06-21T13:57:10.998Z")
        },
        "$push": {
            "Messages": {
                "Content": "This is a new message..."
            }
        }
    },
    {
        "multi": true,
        "upsert": false
    }
)
