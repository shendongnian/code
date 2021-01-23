    class Mango : abc
    {
        public static void Main()
        {
            System.Console.WriteLine("Hello Interfaces");
            abc refabc = new Mango();
            refabc.mymethod();
            abc refabd = new Orange();
            refabd.mymethod();
            Console.ReadLine();
        }
        public void mymethod()
        {
            System.Console.WriteLine("In Mango : mymethod");
        }
    }
    interface abc
    {
        void mymethod();
    }
    class Orange : abc
    {
        public void mymethod()
        {
            System.Console.WriteLine("In Orange : mymethod");
        }
    }
