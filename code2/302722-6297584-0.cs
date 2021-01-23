    string withEncoding;       
    using (System.IO.MemoryStream memory = new System.IO.MemoryStream()) {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(memory)) {
    	    serializer.Serialize(writer, obj, null);
    	    using (System.IO.StreamReader reader = new System.IO.StreamReader(memory)) {
    	        memory.Position = 0;
    	        withEncoding= reader.ReadToEnd();
    	    }
        }
    }
    
    string withOutEncoding= withEncoding.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
