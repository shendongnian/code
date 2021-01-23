     public static string GetConnectionSettings(string searchSetting ) 
     { 
         var con = ConfigurationManager.ConnectionStrings["yourConnectionHere"]‌​.ConnectionString; 
         String[] myString = con.Split(';'); 
         Dictionary<string, string> dict = new Dictionary<string, string>(); 
         
         for (int i = 0; i < myString.Count(); i++) 
         { 
             String[] con3 = myString[i].Split('='); dict.Add(con3[0], con3[1]); 
         } 
          
        return dict[searchSetting]; 
    }
 
