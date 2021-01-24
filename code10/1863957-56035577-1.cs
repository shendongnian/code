    public void SaveFile(string folder, string fileName, string content)
    {
    	using (FileStream fs = new FileStream(Path.Combine(folder, fileName.Trim() + ".cs"), FileMode.Create))
        {
            using (StreamWriter str = new StreamWriter(fs))
            {
                str.WriteLine(content);
                str.Flush();
            }
        }
    }
