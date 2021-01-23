    public class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMarried { get; set; }
        public bool HasChildren { get; set; }        
        public bool IsHappy { get; set; }
        public Person(int id)
        {
            Id = id;
        }
    }
