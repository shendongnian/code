    public Persons ReturnData()
    {            
                     DataSet  vDS = new DataSet();
                     //get data from SQL Server or what ever in a DataSet...
    
                    foreach(System.Data.DataTable t in vDS.Tables)
                    {
                        Persons  vPersons = new Persons();
                        foreach(System.Data.DataRow dr in t.Rows)
                        {
                            Person vPerson = new Person();
                            vPerson.ID = dr("ID");
                            vPerson.FirstName = dr("FirstName");
                            vPerson.LastName = dr("LastName");
            
                            vPersons.All.Add(vPerson);
                        }
            
            
                        return vPersons ;
     }
