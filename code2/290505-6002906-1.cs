    namespace Test_Console
    {
        public class Subscription
        {
            public int Id { get; set; }
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
                    new Subscription { Id = 1, Client = new Client { Invoices = new [] {
                        new Invoice { Id = 1 },
                        new Invoice { Id = 2 },
                        new Invoice { Id = 5 }
                    } } },
                    new Subscription { Id = 2, Client = new Client { Invoices = new [] {
                        new Invoice { Id = 4 },
                        new Invoice { Id = 5 },
                        new Invoice { Id = 5 }
                    } } },
                    new Subscription { Id = 3, Client = new Client { Invoices = new Invoice[] {
                    } } },
                };
    
                var leftSide = new Func<Subscription, int>(x => x.Client.Invoices.Count(i => i.Id == 5));
                var operation = new Func<int, int, bool>((x, y) => x > y);
                var rightSide = 0;
                var whereNumberOne = makeWhere(leftSide, operation, rightSide);
    
                foreach (var s in subscriptions.Where(whereNumberOne).ToList())
                {
                    Console.WriteLine(s.Id);
                }
            }
    
            private static Func<Subscription, bool> makeWhere(Func<Subscription, int> leftSide, Func<int, int, bool> operation, int rightSide)
            {
                return new Func<Subscription, bool>(r => operation(leftSide(r), rightSide));
            }
        }
    }
