    public static Int32 getIdByName(string name)
    {
        var query = from student in DataAccess.getInstance.StudentSet
                    where student.FirstName.Equals(name)
                    select student.Id;
    
        return query.First();
    }
