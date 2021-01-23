    static void Main(string[] args)
    {
        Regex pattern = new Regex(@"[ ]{2,}");   //Pattern = 2 or more space in a string.
        using (StreamReader reader = new StreamReader(@"C:\CSharpProject\in\abc.txt"))
        using (StreamWriter writer = new StreamWriter(@"C:\CSharpProject\out\abc.txt"))
        {
           string content;
           while (null != (content = reader.ReadLine());
              writer.WriteLine (pattern.Replace (content, " "));
   
           writer.Close();
           reader.Close();
        }
    }
