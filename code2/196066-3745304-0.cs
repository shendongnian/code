    private static TextWriter output = Console.Out;
    public static TextWriter Output {
       get {return output;}
       set {output = value ?? Console.Out;}
    }
    public static void WriteLine(string value) {
        output.WriteLine(value);
    }
    public static void WriteLine(string format, params string[] args) {
        output.WriteLine(format, args);
    }
