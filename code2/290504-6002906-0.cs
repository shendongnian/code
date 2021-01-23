    namespace Test_Console
    {
        public class Subscription
        {
            public Client Client { get; set; }
        }
    
        public class Client
        {
            public ICollection<Invoice> Invoices { get; set; }
        }
    
        public class Invoice
        {
            public int Id { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var subscriptions = new[]
                {
                    new Subscription { Client = new Client { Invoices = new [] {
                        new Invoice { Id = 1 },
                        new Invoice { Id = 2 },
                        new Invoice { Id = 5 }
                    } } },
                    new Subscription { Client = new Client { Invoices = new [] {
                        new Invoice { Id = 4 },
                        new Invoice { Id = 5 },
                        new Invoice { Id = 5 }
                    } } },
                    new Subscription { Client = new Client { Invoices = new Invoice[] {
                    } } },
                };
    
                var leftSide = new Func<Subscription, int>(x => x.Client.Invoices.Count(i => i.Id == 2));
                var operation = new Func<int, int, bool>((x, y) => x > y);
                var rightSide = 0;
                var whereNumberOne = makeWhere(subscriptions, leftSide, operation, rightSide);
            }
    
            private static object makeWhere(Subscription[] subscriptions, Func<Subscription, int> leftSide, Func<int, int, bool> operation, int rightSide)
            {
                return subscriptions.Where(r => operation(leftSide(r), rightSide));
            }
        }
    }
