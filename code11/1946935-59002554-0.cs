    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "My Name"
                }
            };
            var clonedUser = users[0].Clone();
            clonedUser.Name = "My Updated Name";
            Console.WriteLine(users[0].Name);
            Console.ReadLine();
        }
    }
    public class User
    {
        public string Name { get; set; }
        public User Clone()
        {
            return (User)MemberwiseClone();
        }
    }
