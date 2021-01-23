     public class Directory
    {
        public List<string> EmailAddresses = new List<string>();
        public List<string> Addresses = new List<string>();
        public void Add(string email, string address)
        {
            EmailAddresses.Add(email);
            Addresses.Add(address);
        }
    }
    class Another
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Directory> _directory = new SortedDictionary<string, Directory>();
            string key, adress, Email;
            int numbr;
        start_again:
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("enter name to be added in the directory");
                key = Console.ReadLine();
                Console.WriteLine("enter number to be added in the directory");
                numbr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter address to be added in the directory");
                adress = Console.ReadLine();
                Console.WriteLine("enter your email-id to be added in the directory");
                Email = Console.ReadLine();
                
                Directory dir = new Directory();
                dir.Add(Email, adress);
                _directory.Add(key, dir);
            }
            Console.WriteLine("do you wish to continue-y/n?");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'y')
            {
                Console.WriteLine("you said yes");
                goto start_again;
            }
            else
            {
                Console.WriteLine("no more entries can be added");
                Console.WriteLine("Name         Number          adress            email");
                foreach (KeyValuePair<string, Directory> d in _directory)
                {
                    Console.WriteLine(string.Format("{0}, {1}, {2}", d.Key, d.Value.Addresses.First(), d.Value.EmailAddresses.First()));
                }
            }
            Console.ReadLine();
        }
