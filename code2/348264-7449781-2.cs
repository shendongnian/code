    namespace ExcelConsole
    {
    using System.IO;
    using ExcelCombine;
    class Program
    {
        public static string Thepath { get; set; }
        public static string TheFirstFile { get; set; }
        public string[] files = null;
        static void Main(string[] args)
        {
            Thepath = @"C:\Users\J\Desktop\TestingFolder\";
            string[] files = Directory.GetFiles(Thepath);
            TheFirstFile = files[0];
            ExcelEngine.CombineWorkBooks(Thepath, "*.xls", Thepath, false, TheFirstFile);
        }
    }
    }
