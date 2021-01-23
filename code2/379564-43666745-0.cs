    byte[] arr;
        using(MemoryStream ms = new MemoryStream())
                        {
                            m.BodyStream.Position = 0;
                            m.BodyStream.CopyTo(ms);
                            arr =  ms.ToArray();
                        }
        
      
    
         string s = Encoding.Unicode.GetString(arr, 0, arr.Length);  
 
