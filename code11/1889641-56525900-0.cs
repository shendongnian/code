    static bool FunctionTest(object o) {
    return true;
    }
    static void Main(string[] args) {
    Dictionary<string, Func<object, bool>> dict = new Dictonary<string, Func<object, bool>>();
    dict.Add("A", ((obj) => { return false; }));
    dict.Add("B", FunctionTest);
    
    Console.WriteLine(dict["A"](1));
    Console.WriteLine(dict["B"](1));
