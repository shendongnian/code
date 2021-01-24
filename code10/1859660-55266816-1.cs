    public static void Main()
    {
        List<Contact> contacts = new List<Contact>();
        contacts.Add(new Contact { firstName = "John", lastName = "Doe", phoneNumber = "7725551234", email = "johndoe@email.com" });
        contacts.Add(new Contact { firstName = "Kent", lastName = "Woods", phoneNumber = "7725551445", email = "kentwoods@email.com" });
        contacts.Add(new Contact { firstName = "Jane", lastName = "Doe", phoneNumber = "7725553355", email = "janedoe@email.com" });
        contacts.Add(new Contact { firstName = "Hank", lastName = "Fowland", phoneNumber = "7725558877", email = "hankfowland@email.com" });
        contacts.Add(new Contact { firstName = "Tracy", lastName = "Yates", phoneNumber = "7725552768", email = "tracyyates@email.com" });
        contacts.Add(new Contact { firstName = "Courtney", lastName = "Wall", phoneNumber = "7725556385", email = "courtneywall@email.com" });
        contacts.Add(new Contact { firstName = "Dawson", lastName = "Stokes", phoneNumber = "7725553098", email = "dawsonstokes@email.com" });
        string search = Console.ReadLine();
        var result = contacts.Where(c => c.firstName == search || c.lastName == search || c.phoneNumber == search || c.email == search).FirstOrDefault();
        Console.WriteLine(result.ToString()); // This will return all the values of Contact. Override ToString() function for you **Bonus
    }
    protected class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public override string ToString()
        {
            return "FirstName =" + firstName + "\t LastName = " + lastName + "\t PhoneNumber = " + phoneNumber + "\t Email = " + email;
        }
    }
