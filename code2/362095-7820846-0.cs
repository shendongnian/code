    User u = new User(); 
    Console.WriteLine(u.print()); // user...
    
    u = new Manager();
    Console.WriteLine(u.print()); // manager...
    
    
    class User { ... 
        public string print(User u)
        {
            return "User...";
        }
    ... }
    class Manager : User { ... 
        public string print(Manager m)
        {
            return "Manager...";
        }
    
    ... }
    
