    public void StoreTheUpdatedData(YourBusinessObject theBusinessObject)
    {
    var yourDataContext = new DataContext()
    var oldObject = (from i in yourDataContext.YourbusinessObjects
                    where (blah equals blah to select your item and only your item)
                    select i).First();
    
    //repeat for all properties in the object
    oldObject.Property = theBusinessObject.Property;
    
    yourDataContext.SaveChanges();
    }
