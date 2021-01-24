    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "My Name",
                    Job = new Job()
                    {
                        Title = "Developer"
                    }
                }
            };
            var clonedUser = users[0].Clone();
            clonedUser.Name = "My Updated Name";
            clonedUser.Job.Title = "Graphic Designer"; //This Won't Work
            Console.WriteLine(users[0].Name);
            Console.WriteLine(users[0].Job.Title);
            Console.ReadLine();
        }
    }
    public class User
    {
        public string Name { get; set; }
        public Job Job { get; set; }
        public User Clone()
        {
            return (User) this.MemberwiseClone();
        }
    }
    public class Job
    {
        public string Title { get; set; }
    }
