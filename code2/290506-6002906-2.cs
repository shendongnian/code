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
                var whereNumberOne = makeWhere<Subscription>(propertyPath);
    
                foreach (var s in subscriptions.Where(whereNumberOne).ToList())
                {
                    Console.WriteLine(s.Id);
                }
            }
    
            private static Func<T, bool> makeWhere<T>(string propertyPath)
            {
                string[] navigateProperties = propertyPath.Split('.');
    
                PropertyInfo nextPropertyInfo;
                var currentType = typeof(T);
                Func<object, object> functoidChain = x => x; // identity function starts the chain
                foreach (var nextProperty in navigateProperties)
                {
                    if (currentType.IsGenericType
                     && currentType.GetGenericTypeDefinition().GetInterfaces().Contains(typeof(IEnumerable)))
                    {
                        nextPropertyInfo = currentType.GetGenericArguments()[0].GetProperty(nextProperty);
                        functoidChain = x =>
                            ((IEnumerable<object>)functoidChain(x))
                            .Count(y => (int)nextPropertyInfo.GetValue(y, null) == 2);
                    }
                    else
                    {
                        nextPropertyInfo = currentType.GetProperty(nextProperty);
                        functoidChain = x => nextPropertyInfo.GetValue(functoidChain(x), null);
                    }
                    currentType = nextPropertyInfo.PropertyType;
                }
                var leftSide = new Func<T, int>(x => (int)functoidChain(x));
                return new Func<T, bool>(r => leftSide(r) > 0);
            }
        }
    }
