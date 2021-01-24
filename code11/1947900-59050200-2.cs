        class Student
    {
        //alle properties van de student
        public string Studentnummer { get; set; }
        public string Naam { get; set; }
        public string Postcode { get; set; }
        public string Telefoonnummer { get; set; }
        //een no-argument constructor
        public Student(string studentnummer, string naam, string postcode, string telefoonnummer)
        {
            Studentnummer = studentnummer;
            Naam = naam;
            Postcode = postcode;
            Telefoonnummer = telefoonnummer;
        }
    }    
