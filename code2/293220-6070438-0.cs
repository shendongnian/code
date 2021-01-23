    using System;
    using System.IO;
    public class Program
    {
        public static int Main(string[] args)
        {
             string[] lines = {"some text1", "some text2", "some text3"};
             File.WriteAllLines(@"/home/myuser/someText.txt", lines);
             return 0;
        }
    }
