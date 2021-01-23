    private static string firstline = String.Empty; // class variable
    
    public static void test1()
    {
    ..
        string[] linesw = obj1.ReadToEnd().Split(new char[] { '\n' });
        firstline = linesw[1]; 
    ..
    }
    
    public static void test2()
    {
    ..
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(firstline);
    ..
    }
