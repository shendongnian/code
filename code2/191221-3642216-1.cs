     using(SchoolEntities context = new SchoolEntities())
     {
         Person newPerson = Person.CreatePerson("Gates", "Bill");
         context.AddToPeople(newPerson);
         context.SaveChanges();
         int newID = newPerson.PersonID;
     }
