    void Main()
    {
    	var contacts = new List<Contact> 
    	{ 
    		{new Contact { FirstName = "Bob", LastName = "Dole" }},
    		{new Contact { FirstName = "Bill", LastName = "Clinton" }}
    	};
    		
    	XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
    	TextWriter textWriter = new StreamWriter(@"contacts.xml");
    	serializer.Serialize(textWriter, contacts);
    	textWriter.Close();	
    }
    public class Contact
    {
    	public string FirstName { get; set; }
    	public string MiddleName { get; set; }
    	public string LastName { get; set; }
    }
