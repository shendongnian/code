    public static void WriteCSV(string file, string content)
    {
       using (StreamWriter sw = new StreamWriter(file))
       {
          sw.Write(content);
       }
    }
