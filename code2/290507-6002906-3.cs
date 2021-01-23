    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections;
    
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
    
                var propertyPath = "Client.Invoices.Id";
                Console.WriteLine("What Id would you like to check " + propertyPath + " for?");
                var propertyValue = int.Parse(Console.ReadLine());
                var whereNumberOne = makeWhere<Subscription>(propertyPath, propertyValue);
    
                Console.WriteLine("The following Subscription objects match:");
                foreach (var s in subscriptions.Where(whereNumberOne).ToList())
                {
                    Console.WriteLine("Id: " + s.Id);
                }
            }
    
            private static Func<T, bool> makeWhere<T>(string propertyPath, int propertyValue)
            {
                string[] navigateProperties = propertyPath.Split('.');
    
                var currentType = typeof(T);
                var functoidChain = new List<Func<object, object>>();
                functoidChain.Add(x => x);  // identity function starts the chain
                foreach (var nextProperty in navigateProperties)
                {
                    // must be inside loop so the closer on the functoids works properly
                    PropertyInfo nextPropertyInfo;
    
                    if (currentType.IsGenericType
                     && currentType.GetGenericTypeDefinition().GetInterfaces().Contains(typeof(IEnumerable)))
                    {
                        nextPropertyInfo = currentType.GetGenericArguments()[0].GetProperty(nextProperty);
                        functoidChain.Add(x =>
                            ((IEnumerable<object>)x)
                            .Count(y => (int)nextPropertyInfo.GetValue(y, null) == propertyValue)
                        );
                    }
                    else
                    {
                        nextPropertyInfo = currentType.GetProperty(nextProperty);
                        functoidChain.Add(x => nextPropertyInfo.GetValue(x, null));
                    }
                    currentType = nextPropertyInfo.PropertyType;
                }
                // compose the functions together
                var composedFunctoidChain = functoidChain.Aggregate((f, g) => x => g(f(x)));
                var leftSide = new Func<T, int>(x => (int)composedFunctoidChain(x));
                return new Func<T, bool>(r => leftSide(r) > 0);
            }
        }
    }
