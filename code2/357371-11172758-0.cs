     public static string  ToDataString(this string prm)
       {
           if (prm == null)
           {
               return "NULL";
           }
           else
           {
               return "'" + prm.Replace("'", "''") + "'";
           }
       }
    string Field1="Val";
    string Field2=null;
    
    strin s =string.format("Set Value:{0}, NulValue={1}",Field1.ToDataString(), Field2.ToDataString())
    
