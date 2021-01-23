    public static T Load<T>(string FileSpec) {
    	XmlSerializer formatter = new XmlSerializer(typeof(T));
    
        using (FileStream aFile = new FileStream(FileSpec, FileMode.Open)) {
    		byte[] buffer = new byte[aFile.Length];
    		aFile.Read(buffer, 0, (int)aFile.Length);
    
    		using (MemoryStream stream = new MemoryStream(buffer)) {
    			return (T)formatter.Deserialize(stream);
    		}
    	}
    }
    
    public static void Save<T>(T ToSerialize, string FileSpec) {
    	Directory.CreateDirectory(FileSpec.Substring(0, FileSpec.LastIndexOf('\\')));
    	FileStream outFile = File.Create(FileSpec);
    	XmlSerializer formatter = new XmlSerializer(typeof(T));
    
    	formatter.Serialize(outFile, ToSerialize);
    }
