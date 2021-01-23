    public static void AppendToFile(string fileToWrite, byte[] DT)
    {
    	using (FileStream FS = new FileStream(fileToWrite, File.Exists(fileToWrite) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write)) {
    		FS.Write(DT, 0, DT.Length);
    		FS.Close();
    	}
    }
