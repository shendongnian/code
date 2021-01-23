    private struct MyThing
    {
        public float MyFloat;
    }
    private static void Main(string[] args)
    {
        MyThing f, s;
        f.MyFloat = 0.0f;
        s.MyFloat = -0.0f;
        Console.WriteLine(f.Equals(s));  // prints False
        Console.WriteLine(0.0f == -0.0f); // prints True
    }
