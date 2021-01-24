    public class MyClass1
    {
        public string AAAAA { get; set; }
        public string BBBBB { get; set; }
        public string CCCCC { get; set; }
        public string DDDDD { get; set; }
    }
    public class MyClass2
    {
        public string AAAAA { get; set; }  // same as MyClass1 
        public string BBBBB { get; set; }  // same as MyClass1 
        public string TTTTT { get; set; }
    }
    public static class Helper
    {
        public static string Print(IExtra obj)
        {
            string message = "";
            message += obj.AAAAA;  // this parameter is in both MyClass1 and MyClass2
            message += obj.BBBBB;  // this parameter is in both MyClass1 and MyClass2
            return message;
        }
    }
    public interface IExtra
    {
        string AAAAA { get; set; }
        string BBBBB { get; set; }
        string Print { get; }
    }
    public class MyClass1WithPrint : MyClass1, IExtra
    {
        public string Print => Helper.Print(this);
    }
    public class MyClass2WithPrint : MyClass2, IExtra
    {
        public string Print => Helper.Print(this);
    }
