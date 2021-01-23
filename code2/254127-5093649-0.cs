    IList<MyObject> myObjList = new List<MyObject>();
    
    while (reader.Read()){
      int fieldCount = reader.FieldCount;
      MyObject myObj = new MyObject();
      for(int i=0;i<fieldCount;i++){
        SetProperty(myObj, reader.GetName(i), reader.GetOrdinal(i));
      }
      myObjList.Add(myObj);
    }
    bool SetProperty(object obj, String propertyName, object val) {
        try {
            //get a reference to the PropertyInfo, exit if no property with that 
            //name
            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            if (pi == null) then return false;
            //convert the value to the expected type
            val = Convert.ChangeType(val, pi.PropertyType);
            //attempt the assignment
            pi.SetValue(obj, val, null);
            return true;
        }
        catch {
            return false;
        }
    }
