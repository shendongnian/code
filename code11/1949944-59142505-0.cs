    using (var db= new DatabaseModel())
    {
         Contact contact = db.Contacts.Find(id);
         if(contact != null){
         EventContact eventContact = db.EventContacts.Where(x=>x.contactId == 
            contact.Id).ToList();
          foreach(var item in eventVContact){
            db.contact.Remove(item);
            db.SaveChanges();
           }
         }
         if(eventContact?.Any()??true){
          db.Contact.Remove(contact);
          db.SaveChanges();
         }
         
    }
