    public class Class
    {
        static void Main(string[] args)
        {
            User u1 = new User("1");
            User u2 = new User("1");
            Console.WriteLine(u1.Equals(u2));
            u2.Lic = "2";
            Console.WriteLine(u1.Equals(u2));
        }
    }
    public class User
    {
        public string Lic;        
        public User(string lic)
        {
            this.Lic = lic;
        }
        
        public override bool Equals(object obj)
        {
            return (obj as User).Lic == Lic;
        }
    }
