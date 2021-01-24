    public class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
    
        public IEnumerable<Address> Addresses { get; set; }
    }
    
    public class Address 
    {
        public int AddressID { get; set; }
        public int PersonID { get; set; }
        public string AddressLine1 { get; set; }
        public string City{ get; set; }
        public string StateCode { get; set; }
        public string PostalCode { get; set; }
    
        public IEnumerable<Note> Notes { get; set; }
    }
    
    public class Note 
    {
        public int AddressID { get; set; }
        public int NoteID { get; set; }
        public string NoteText { get; set; }
    }
    
    
    string cmdTxt = @"SELECT p.*, a.*, n.* 
        FROM Person p
        LEFT OUTER JOIN Address a ON p.PersonId = a.PersonId
        LEFT OUTER JOIN Note n ON a.AddressId = n.AddressId
        WHERE p.PersonId = @personID";
    var results = await conn.QueryAsync<Person,Address,Note,Tuple<Person,Address,Note>>(cmdTxt, 
       map: (p,a,n)=>Tuple.Create((Person)p, (Address)a, (Note)n),
       param: new { personID = 1 });
    
    if(results.Any()) {
        var person = results.First().Item1;   //the person
        var addresses = results.Where(n => n.Item2 != null).Select(n=>n.Item2); //the person's addresses
        var notes = results.Where(n => n.Item3 != null).Select(n=>n.Item3);  //all notes for all addresses
        if(addresses.Any()) {
             person.Addresses = addresses.ToList(); //add the addresses to the person
             foreach(var address in person.Addresses) {
                 var address_notes = notes.Where(n=>n.AddressId==address.AddressId).ToList(); //get any notes
                 if(address_notes.Any()) {
                     address.Notes = address_notes; //add the notes to the address
                 }
             }
        }
    }
