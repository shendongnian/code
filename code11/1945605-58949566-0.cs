    public class Coontainer {
        public string Test { get; set; }
        public string Slab { get; set; }
    }
    
    public static void Main(string[] args) {
        var test = new Container { Text = "test", Slab = "slab"};
        Console.WriteLine(test.Text); //outputs test
        Console.WriteLine(TestMethod(test));  //outputs slab
    }
    
    public static string TestMethod(dynamic obj) {
        return obj.Slab;
    }
