public File updateFile(string filePath){
    List<string> modifiedNames;
    using (StreamReader sr = File.OpenText(path))
    {
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            s = s + randomlyGeneratedSuffix();
            newEntries.add(s)
            
        }
    }
    using (StreamWriter sw = new StreamWriter("names.txt")) {
        foreach (string s in modifiedNames) {
            sw.WriteLine(s);
        }
    
    }
    // return new file?
}
