     static void InitDbCheck()
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PersonModelContainer>());
                using (var db = new PersonModelContainer())
                {
                    //accessing a record will trigger to check db.
                    int recordCount = db.Contacts.Count();
                }
            }
    
            static void Main(string[] args)
            {
              
    
    
                using (var db = new PersonModelContainer())
                {
                    // Save some data
                    db.Contacts.Add(new Contact { Name = "Bob" });
                    db.Contacts.Add(new Contact { Name = "Ted" });
                    db.Contacts.Add(new Contact { Name = "Jane" });
                    db.SaveChanges();
    
                    // Use LINQ to access data
                    var people = from p in db.Contacts
                                 orderby p.Name
                                 select p;
    
                    Console.WriteLine("All People:");
                    foreach (var person in people)
                    {
                        Console.WriteLine("- {0}", person.Name);
                    }
    
                    // Change someones name
                    db.Contacts.First().Name = "Janet";
                    db.SaveChanges();
                }
            }
