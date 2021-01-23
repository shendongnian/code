    public static void WriteAllLines(string path, string[] contents, Encoding encoding)
    {
    if (contents == null)
        {
            throw new ArgumentNullException("contents");
        }
        using (StreamWriter writer = new StreamWriter(path, false, encoding))
        {
            foreach (string str in contents)
            {
                writer.WriteLine(str);
            }
        }
    }
 
    public static void WriteAllText(string path, string contents, Encoding encoding)
    {
        using (StreamWriter writer = new StreamWriter(path, false, encoding))
        {
            writer.Write(contents);
        }
    }
 
 
 
