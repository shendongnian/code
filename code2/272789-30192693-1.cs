    using System;
    using System.IO;
    static void Main(string[] args)
    {
        try
        {
            StreamReader sr = new StreamReader("C:\\Test\\temp.txt");
            Console.WriteLine(sr.ReadLine().Length);
        }
        catch (Exception e)
        {
             Console.WriteLine(e.StackTrace);
        }
    }
            
