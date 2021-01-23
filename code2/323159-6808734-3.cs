    using System.Linq;
    // create context    
    using(DBDataContext db = new DBDataContext ())
    {
        // create table entry
        WF entry= new WF();
        // set values of the table 
        entry.someColumnName = "something";
        db.WFs.InsertOnSubmit(entry);
        db.SubmitChanges();
    }
