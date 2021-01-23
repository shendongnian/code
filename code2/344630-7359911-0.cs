    private void Test()
    {
        PersonalInfo pi = new PersonalInfo();
        pi.Contact = new Contact();
        pi.Contact.Name = "test";
    }
    public class Contact
    {
        public string Name {get;set;}
        public string Telephone {get;set}
    }
    public class PersonalInfo
    {
        public Contact Contact {get;set;}
    }
