    public static class ListOfPersonExtension
    {
        public static void Add(this List<EmailData> list, 
            string firstName, string lastName, string location)
        {
            if (null == list)
                throw new NullReferenceException();
            var emailData = new EmailData
                                {
                                    FirstName = firstName, 
                                    LastName = lastName, 
                                    Location = location
                                };
            list.Add(emailData);
        }
    }
