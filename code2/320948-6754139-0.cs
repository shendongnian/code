    private static string Search_For_Registry_Keys(RegistryKey rk, string search)
     {
         string reg_result = "";
         if (rk.SubKeyCount > 0)
         {
             foreach (var temp in rk.GetSubKeyNames())
             {
                 if (temp.ToLower().Contains(search.ToLower()))
                 {
                     reg_result = (String.Format(rk.Name + "\\" + temp));
                     MessageBox.Show(String.Format("Match Found In Registry Key {0} Present At Location {1}", temp, rk.Name + "\\" + temp));
                     return reg_result;
                 }
             }
             foreach (var temp in rk.GetSubKeyNames())
             {
                 try
                 {
                     if (rk.OpenSubKey(temp).SubKeyCount > 0)
                     {
                         // Added and changed lines here
                         string retVal = Search_For_Registry_Keys(rk.OpenSubKey(temp), search);
                         if (!retVal.Equals(""))
                         {
                             return retVal;
                         }
                     }
                 }
                 catch
                 {
                 }
             }
         }
         // Added this line
         return reg_result;
     }
