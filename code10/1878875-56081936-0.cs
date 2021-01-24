using System.Linq;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Card : Entity
    {
        public string Number { get; set; }
        public One<Customer> Customer { get; set; }
        public Many<Transaction> Transactions { get; set; }
        public Card() => this.InitOneToMany(() => Transactions);
    }
    public class Transaction : Entity
    {
        public string OrderNumber { get; set; }
    }
    public class Customer : Entity
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("orders-test");
            var customer = new Customer { Name = "Customer 1" };
            customer.Save();
            var card = new Card { Number = "00000001", Customer = customer.ToReference() };
            card.Save();
            var transaction = new Transaction { OrderNumber = "12345" };
            transaction.Save();
            card.Transactions.Add(transaction);
            var transactions = DB.Collection<Card>()
                                 .Where(c => c.Number == "00000001")
                                 .SingleOrDefault()
                                 .Transactions.Collection()
                                              .Where(t => t.OrderNumber == "12345")
                                              .ToList();
        }
    }
}
results in the below aggregation query:
{ "$match" : 
    { "ParentID" : ObjectId("5cd5ac4c921e4323701995b0") } }, 
    { "$lookup" : { "from" : "Transactions",
                    "localField" : "ChildID", 
                    "foreignField" : "_id", "as" : "children" } }, 
    { "$unwind" : "$children" }, 
    { "$project" : { "children" : "$children", "_id" : 0 } }, 
    { "$match" : { "children.OrderNumber" : "12345" } }
