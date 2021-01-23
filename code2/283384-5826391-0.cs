    public class Contact
    {
    
        public string Name {get; set;}
        public string Contact {get; set;}
        public string Product {get; set;}
        public int Quantity {get; set;}
    }
    ...
    public IEnumerable<Contact> GetContacts()
    {
        //make this read line by line if it is big!
        string[] lines = File.ReadAllLines("C:/AddressBook/Customers.txt");
        for (int i=0;i<lines.length;i += 4)
        {
            //add error handling/validation!
            yield return new Contact()
            {
                  Name = lines[i],
                  Contact = lines[i+1],
                  Product = lines[i+2],
                  Quantity = int.Parse(lines[i+3]
             };
        }
    }
    private void buttonSearch_Click(object sender, EventArgs e)
    {
        ...
        var results = from c in GetContacts()
                     where c.Name == name ||
                           c.Contact == contact
                     select c;
        ...
    }
