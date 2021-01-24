    private static int _myVar;
    static int MyVar {
        get => _myVar;
        set {
            _myVar = value;
            if(value == 0) Console.WriteLine("Dead");
        }
    }
    public static void Main(){
        if(Console.ReadLine().Equals("kill")){
            MyVar = 0;
        }
    }
