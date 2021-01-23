    private static string[] InternalReadAllLines(string path, Encoding encoding)
    {
        List<string> list = new List<string>();
        using (StreamReader reader = new StreamReader(path, encoding))
        {
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                list.Add(str);
            }
        }
        return list.ToArray();
    }
