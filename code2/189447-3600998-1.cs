    public static string ByLastName(Person p)
    {
         return p.LastName;
    }
     db.People.Where(p=>p.age > 25).OrderBy(ByLastName);
