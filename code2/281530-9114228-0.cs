    using (FileStream fs = File.OpenRead (path)) {
     var data = new byte[checked((int)fs.Length)];
     int i = 0;
     int read;
         
     using (var ms = new MemoryStream (checked((int)fs.Length))) {
          
      while ((read = fs.Read (data, 0, data.Length)) > 0) {
       ms.Write (data, 0, read);
       i += read;
      }
          
      byte[] hive = ms.ToArray ();
      char[] cList = new char[fs.Length];
          
      i = 0;
      foreach (byte b in hive)
       cList[i++] = (char)b;
          
             string d = new string (cList);
     
          
      int all = 0;
          
      foreach (Match mx in lf.Matches (d)) { //you can change out the regex you want here.
       byte[] bb = new byte[mx.Value.Length];
       char[] cb = new char[mx.Value.Length];
           
       for (int k = 0; k < mx.Value.Length; k++) {
        bb[k] = (byte)mx.Value[k];
        cb[k] = (char)bb[k];
        
       }
       
       all++;
       
       //Console.WriteLine (new string (cb));
      }
      
      Console.WriteLine (all.ToString ());
      all = 0;
     }
    }
