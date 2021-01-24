    public class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public Address[] Addresses { get; set; }
    }
    public class Address 
    {
        public int AddressID { get; set; }
        public int PersonID { get; set; }
        public string AddressLine1 { get; set; }
        public string City{ get; set; }
        public string StateCode { get; set; }
        public string PostalCode { get; set; }
        public Note[] Notes { get; set; }
    }
    public class Note 
    {
        public int AddressID { get; set; }
        public int NoteID { get; set; }
        public string NoteText { get; set; }
    }
