    class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.AppendText(@"C:\Temp\blah").WriteLine("Boo");
        }
    }
