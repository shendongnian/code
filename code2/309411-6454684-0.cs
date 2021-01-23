    public static string getDatastoreName(string name)
    {
         var result = GetDatastore().SingleOrDefault(s => s.Value == name);
         if (result != null)
         {
             return result.Text;
         }
         throw /* some exception */
    }
