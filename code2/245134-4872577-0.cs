    static void Main(string[] args) {
       var dt = DateTime.Now;
       CSVprocess.ImportDataC("test.csv"); // C# implementation
       System.Console.WriteLine("Time {0}", DateTime.Now - dt);
       dt = DateTime.Now;
       CSVImport.ImportData("test1.csv"); // F# implementation
       System.Console.WriteLine("Time {0}", DateTime.Now - dt);
    }
