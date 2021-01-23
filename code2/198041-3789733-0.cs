    IQueryable<Contact> contacts = GetContacts(); 
    string query = "new Func<IQueryable<Contact>, IQueryable<Contact>>(contracts =>
                      from contact in contacts 
                      where contact.Name == \"name\" 
                      select contact)"; 
    var res = Mono.CSharp.Evaluator.Evaluate(query); 
