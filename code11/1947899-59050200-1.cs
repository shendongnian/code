     class Klas
    {
        public string Klascode { get; set; }
        public string Klasnaam { get; set; }
        public List<Student> Students { get; set; }
        public Klas(string klasnummer, string klasnaam, List<Student> students)
        {
            Klascode = klasnummer;
            Klasnaam = klasnaam;
            Students = students;
        }
    }     
