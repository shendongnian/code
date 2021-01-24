csharp
public class DetailsAndAcount {
       public List<Account> acc {get; set;}
       public Person person {get; set;}
}
public ActionResult UserDeltails(string ID) {
    var accList = new List<Account>();
    var personList  = new Person();
    var detailsAndAcount  = new DetailsAndAcount ();
    ....
    detailsAndAcount.acc = db.Accounts.Where(c => c.ID == ID).ToList();
    detailsAndAcount.person = db.Persons.Where(c => c.ID== ID).First();
    return View(detailsAndAcount);
}
Also make sure to get your namings correctly, if something is a collection give it a name in plural. 
