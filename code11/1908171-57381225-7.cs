    class Program {
            static void Main(string[] args) {
                // Array of concrete types assigned to dynamic enumerable
                IEnumerable<dynamic> enumerable = new Person[] {
                    new Person { BirthDate = new DateTime(1975, 8, 14), FirstName = "Alan",  LastName = "Smith" },
                    new Person { BirthDate = new DateTime(2006, 1, 26), FirstName = "Elisa",  LastName = "Ridley" },
                    new Person { BirthDate = new DateTime(1993, 12, 1), FirstName = "Randy",  LastName = "Knowles" },
                    new Person { BirthDate = new DateTime(1946, 5, 8), FirstName = "Melissa",  LastName = "Fincher" }
                };
    
                IQueryable<dynamic> queryable = enumerable.AsQueryable();
    
                // Helper method to write data to console
                void Write(IEnumerable<dynamic> collection) {
                    foreach (var item in collection) {
                        Console.WriteLine($"{item.FullName} born {item.BirthDate.ToShortDateString()}");
                    }
                    Console.WriteLine();
                }
    
                // Property access on dynamic object
                var youngsters = enumerable
                    .Where(m => m.Age < 21);
    
                Console.WriteLine("Young people to test property acces:");
                Write(youngsters);
    
                // Index access on dynamic object
                var adults = enumerable
                    .Where(m => m["Age"] > 20 && m["Age"] < 60);
    
                Console.WriteLine("Adult people to test index access:");
                Write(adults);
    
                // Composed lambda expression for queryable (be aware it is not going to work with EF)
                var seniors = queryable
                    .Where(ExpressionFactory.PropertyGreaterThanPredicate("Age", 59));
    
                Console.WriteLine("Senior people to test property access lambda expression:");
                Write(seniors);
    
                // Composed lambda expression for queryable (be aware it is not going to work with EF)
                var some = queryable
                    .Where(ExpressionFactory.IndexLessThanPredicate("Age", 60));
    
                Console.WriteLine("Some people to test index access lambda expression:");
                Write(some);
    
                Console.ReadKey();
            }
        }
