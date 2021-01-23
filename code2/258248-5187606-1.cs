    [WebGet(UriTemplate = "/?name={name}", ResponseFormat = WebMessageFormat.Xml)]  
    public List<Custommer> GetCollection(string name)  
    {  
            try  
            {      
                 db.OpenDbConnection();  
                 // Call to SQL stored procedure        
                    DataTable vDT = db.GetCustFromName(name);
     
                    //Create a new list of custommer
                    List<Custommer> vListOfCustommer = new List<>();
      
                    //loop all row from the sp from database.
                    foreach (DataRow r in vDT) {
                        Custommer vCustommer = new Custommer();
                        vCustommer.ID =r["ID"];
                        vCustommer.Name= r["Name"];
                        vListOfCustommer.add(vCustommer);
                    }
                    // return list of custommer
                    return vListOfCustommer;
            }  
            catch (Exception e)  
            {  
                Log.Error("Stored Proc execution failed. ", e);  
            }  
            finally  
            {  
                db.CloseDbConnection();  
            }  
            return new List<Custommer>();  
    }
