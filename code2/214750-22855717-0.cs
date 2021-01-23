    public class demo
    {
       private demo()
        {
            Console.WriteLine("This is no parameter private constructor");
        }
        public demo(int a)
        {
            demo d = new demo('c');// u can call both private contstructors from here
            demo dd = new demo();
            Console.WriteLine("This is one parameter public constructor");
        }
        private demo(char a)
        {
            Console.WriteLine("This is one parameter public constructor::" + a);
        }}
