    public class Student
    {
        public string StudentNummer { get; set; }
        public string Naam { get; set; }
        public string PostCode { get; set; }
        public string TelefoonNummer { get; set; }
        public List<string> Vakken { get; set; }
        public static Student Create(string studentNummer, string naam, string postCode, string telefoonNummer, List<string> vakken)
        {
            return new Student(studentNummer, naam, postCode, telefoonNummer, vakken);
        }
        private Student(string studentNummer, string naam, string postCode, string telefoonNummer, List<string> vakken)
        {
            StudentNummer = studentNummer;
            Naam = naam;
            PostCode = postCode;
            TelefoonNummer = telefoonNummer;
            Vakken = vakken;
        }
        private Student()
        {
            Vakken = new List<string>();
        }
        public override string ToString()
        {
            return $"Studentnummer: {StudentNummer}, naam: {Naam}, postcode: {PostCode}, telefoonnummer :{TelefoonNummer}, aantal vakken: {String.Join(", ", Vakken)}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var student = Student.Create("S101010", "Voornaam Achternaam", "1111AT", "31+ 0571 123456", 
                new List<string>()
                {
                    "Voorbeeld vak 1", "Voorbeeld vak 2"
                });
            Console.WriteLine(student.ToString());
        }
    }
