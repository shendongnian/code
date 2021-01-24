    public bool FieldSearch(object a, string b)
    {
      //Get the type of your object, to loop through its properties
      Type t = a.GetType();
      //loop and check (the loop stops once the first property that matches has been found!)
      foreach(PropertyInfo p in t.GetProperties())
      {
        if(p.GetValue(a).ToString()==b)
        {
        return true;
        }
      }
      return false;
    }
