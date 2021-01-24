    <#
    public void SaveFile(string folder, string fileName, string content)
    {
    	using (FileStream fs = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
        {  
            using (StreamWriter str = new StreamWriter(fs))
            {
            str.WriteLine(content);
            str.Flush();
            }
        }
    }
    public void RemoveFilesFromFolder(string path)
    {
    	Array.ForEach(Directory.GetFiles(path), File.Delete);
    }
    #>
