c#
    public class Container {
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
This way restricts you not to use an anonymous type. But it will work fine.
2) or if you like anonymous types, use casting with ExpandoObject. 
Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?redirectedfrom=MSDN&view=netframework-4.8
Sample: https://sebnilsson.com/blog/convert-c-anonymous-or-any-types-into-dynamic-expandoobject/
