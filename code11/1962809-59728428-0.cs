    namespace blazor 
    {
        public class Patient
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Patient() { }
    
            public Patient(int id, string name, string lname, DateTime date)
            {
                ID = id;
                Name = name;
                LastName = lname;
                DateOfBirth = date;
            }
        }
    }
