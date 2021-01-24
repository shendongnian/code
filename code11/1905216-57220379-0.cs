    class Program
    {
        static void Main(string[] args)
        {
            File file = TagLib.File.Create(@"C:\Users\MSU-01\Desktop\asd.mp3");
            string title = file.Tag.Title;
            Console.WriteLine(title);
            Console.ReadLine();
        }
    }
