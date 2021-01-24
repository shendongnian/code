    public void SaveToDb()
    {
     bool yes =true; //You can add true or false according to your needs
     var db2 = new DatabaseEntities();
     db2.Table.Add(new Table(){ Name=Name, Yes=yes } 
     db2.SaveChanges();
    }
