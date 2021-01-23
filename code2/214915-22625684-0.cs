     class Mango : abc
    {
        public static void Main()
        {
            System.Console.WriteLine("Hello Interfaces");
            Mango refDemo = new Mango();
            refDemo.mymethod();
            Orange refSample = new Orange();
            refSample.mymethod();
         
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
