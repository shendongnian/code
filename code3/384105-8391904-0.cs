    public class EmailData
    {
        public EmailData(string firstName, string lastName, string location)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
        }
        public string FirstName{ set; get; }
        public string LastName { set; get; }
        public string Location{ set; get; }
    }
