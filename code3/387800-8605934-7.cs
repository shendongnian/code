    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User { FirstName = "John", LastName = "Doe" });
            users.Add(new User { FirstName = "Jane", LastName = "Doe" });
            var userProxies = users
                .ProxyAddMixins(u => new UserProxyImpl { User = u })
                .ToList();
            Console.WriteLine("First\tLast\tFull");
            foreach (var userProxy in userProxies)
            {
                Console.WriteLine("{0}\t{1}\t{2}",
                    DataBinder.Eval(userProxy, "FirstName"),
                    DataBinder.Eval(userProxy, "LastName"),
                    DataBinder.Eval(userProxy, "FullName"));
            }
            Console.ReadLine();
        }
    }
