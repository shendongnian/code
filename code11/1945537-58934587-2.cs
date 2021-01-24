    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                //informatie over de studen
                Studentnummer = "S101010",
                Naam = "Voornaam Achternaam",
                Postcode = "1111AT",
                Telefoonnummer = "31+ 0571 123456"
            };
            student.Wakken.Add("Voorbeeld vak 1");
            student.Wakken.Add("Voorbeeld vak 2");
    
            Console.WriteLine(student.ToString());
        }
    }
    
    class Student
    {
        //alle properties van de student
        public string Studentnummer { get; set; }
        public string Naam { get; set; }
        public string Postcode { get; set; }
        public string Telefoonnummer { get; set; }
        public List<string> Wakken { get; } = new List<string>();
    
        //een no-argument constructor
        public Student()
        { }
        //override van de ToString methode? (ik weet niet of dit ook de goede manier is)
        public override string ToString()
        {
            return $"Studentnummer: {Studentnummer}, naam: {Naam}, postcode: {Postcode}, telefoonnummer :{Telefoonnummer}, aantal vakken: {String.Join(", ", Wakken)}";
        }
    
    }
