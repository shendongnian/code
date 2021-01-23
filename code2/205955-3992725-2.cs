    class Program
    {
        static void Main(string[] args)
        {
            User u = new User
            {
                // Here we set our non-persisted property data
                AssociatedLeadIds = new Guid[] 
                {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                },
                // The rest are persisted properties
                ApplicationId = Guid.NewGuid(),
                UserName = "TestUser",
                LoweredUserName = "testuser",
                LastActivityDate = DateTime.Now,
                IsAnonymous = false
            };
            using (Service1Client svc = new Service1Client())
            {
                // Here we call the service operation 
                // and print the response to the console
                Console.WriteLine(svc.DoStuff(u));
            }
            Console.ReadKey();
        }
    }
