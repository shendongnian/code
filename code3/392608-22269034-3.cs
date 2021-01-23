     public bool IsFilePresent(string fileName)
     {
         return System.IO.File.Exists(string.Format(@"{0}\{1}", ApplicationData.Current.LocalFolder.Path, fileName);
     }
 
