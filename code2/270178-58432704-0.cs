    class Program
    {
        static void Main(string[] args)
        {
            List<FirstName> firstNames = new List<FirstName>();
            firstNames.Add(new FirstName { ID = 1, Name = "John" });
            firstNames.Add(new FirstName { ID = 2, Name = "Sue" });
            List<LastName> lastNames = new List<LastName>();
            lastNames.Add(new LastName { ID = 1, Name = "Doe" });
            lastNames.Add(new LastName { ID = 3, Name = "Smith" });
            HashSet<int> ids = new HashSet<int>();
            foreach (var name in firstNames)
            {
                ids.Add(name.ID);
            }
            foreach (var name in lastNames)
            {
                ids.Add(name.ID);
            }
            List<FullName> fullNames = new List<FullName>();
            foreach (int id in ids)
            {
                FullName fullName = new FullName();
                fullName.ID = id;
                FirstName firstName = firstNames.Find(f => f.ID == id);
                fullName.FirstName = firstName != null ? firstName.Name : string.Empty;
                LastName lastName = lastNames.Find(l => l.ID == id);
                fullName.LastName = lastName != null ? lastName.Name : string.Empty;
                fullNames.Add(fullName);
            }
        }
    }
    public class FirstName
    {
        public int ID;
        public string Name;
    }
    public class LastName
    {
        public int ID;
        public string Name;
    }
    class FullName
    {
        public int ID;
        public string FirstName;
        public string LastName;
    }
