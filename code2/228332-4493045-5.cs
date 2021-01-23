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
                            int vtryInt;
                            int.TryParse(dr["ID"].ToString(), out vtryInt);
                            vPerson.ID = vtryInt;
                            vPerson.FirstName = dr["FirstName"].toString();
                            vPerson.LastName = dr["LastName"].toString();
            
                            vPersons.All.Add(vPerson);
                        }
            
            
                        return vPersons ;
     }
