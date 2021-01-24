    public class CSVEntry
    {
        public string Email { get; set }
        public string Name { get; set; }
        public IPAddress IPAddress { get; set; }
        public string Action { get; set; } 
        public DateTime Timestamp { get; set; }       
        public CSVEntry(string email, string name, IPAddress ip, string action, DateTime timestamp)
        {
            Email = email;
            Name = name;
            IPAddress = ip;
            Action = action;
            Timestamp = timestamp;
        }
        public static CSVEntry Parse(string csvLine)
        {
            string[] args = csvLine.Split(';');
            if (args.Length >= 5)
            {
                string email = args[0];
                string name = args[1];
                IPAddress ip = IPAddress.Parse(args[2]);
                string action = args[3];
                DateTime timestamp = DateTime.Parse(args[4]);
                return new CSVEntry(email, name, ip, action, timestamp);
            }
            return null;
        }
    }
