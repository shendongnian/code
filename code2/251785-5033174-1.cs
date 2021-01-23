    public class C
    {
        public void Print(string str) { Console.WriteLine("string: " + string); }
        public void Print(int i) { Console.WriteLine("int: " + i); }
        public void Print(object obj) { Console.WriteLine("object: " + obj.ToString()); }
    }
    var c = new C();
    c.Print("1"); // string: 1
    c.Print(1); // int: 1
    c.Print((object)1); // object: 1
