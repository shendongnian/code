    class Klas
    {
        // these properties are pretty self-explanatory
        public string Klascode { get; set; }
        public string Klasnaam { get; set; }
    	// a Klas has a List of Students
    	// I changed List to IList (i.e., an interface rather than a class)
    	// for this example it doesn't matter.
    	// however, when you get to the point of creating your own interfaces
    	// there *can* be a benefit to it (not going to explain now).
        public IList<Student> Students { get; set; }
    
    	// A constructor allows you to set the values of an object at the time of creation.
    	// In fact, in this case, you *have* to supply all 3 properties
    	// the take-away here is that this is not required.
        public Klas(string klasnummer, string klasnaam, List<Student> students)
        {
            Klascode = klasnummer;
            Klasnaam = klasnaam;
            Students = students;
        }
    }
    // let's show some stuff
    public static void Main(string[] args)
    {
    	// You already kow how to create students and how to assign them to a list immediately
    	IList<Student> studentlijst = new List<Student>()
    	{
    		new Student("S101010", "Voornaam - Achternaam", "0000xx", "+06 012345678"),
    		new Student("S202020", "Voornaamer - Achternaamer", "0000xx", "+06 1234 5678")
    	};
    	// let's create a single Klas
    	Klas KlasA = new Klas("A0", "Eerste klas", studentenlijst);
    	// that gives you a KlasA of type Klas, with all info
    	// let's list the students:
    	foreach (var student in KlasA.Students)
    	{
    		Console.WriteLine(string.Format("Studentnummer: {0} - Naam: {1}", student.Studentnummer, student.Naam));
    	}
    	
    	// But wait! You want to add another student.
    	// In this case you could simply do:
    	KlasA.Students.Add(new Student("0123", "zwarte", "piet", "+34 123 456 789"));
    }
