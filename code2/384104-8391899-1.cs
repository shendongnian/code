    public class EmailList : List<EmailData>
    {
        public void Add(string firstName, string lastName, string location)
        {
            var data = new EmailData 
                       { 
                           FirstName = firstName, 
                           LastName = lastName,
                           Location = location
                       };
            this.Add(data);
        }
    }
