      DateTime? d = null;
      System.Diagnostics.Debug.WriteLine("HasValue1 = {0}", d.HasValue); //False
      d = DateTime.Now;
      System.Diagnostics.Debug.WriteLine("HasValue2 = {0}", d.HasValue); //True
      d = null;
      System.Diagnostics.Debug.WriteLine("HasValue3 = {0}", d.HasValue); //False
