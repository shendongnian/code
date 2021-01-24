    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, born on {BirthDate}, lives at: {Address}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "\nFIRSTNAMEJOHN\nLASTNAMESMITH\nADDRESS1590 GRACE STREET\nBIRTHDATE04201969";
            var user = new User();
            var properties = typeof(User).GetProperties();
            var settings = str.Split('\n');
            foreach (var property in properties)
            {
                foreach (var setting in settings)
                {
                    if (setting.StartsWith(property.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        property.SetValue(user, setting.Substring(property.Name.Length));
                    }
                }
            }
            Console.WriteLine(user);
            GetKeyFromUser("\n\nDone! Press any key to exit...");
        }
    }
