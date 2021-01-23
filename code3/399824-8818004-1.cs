    public class Test1
    {
        public Int32 addNumer (Int32 a, Int32 b)
        {
             return (a+b);
        }
    }
    static void Main (string[] args)
    {
        Byte a = 10;
        Byte b = 20;
        object test = new Test1();
        //note how I cast a and b to int 
        //int is an alias to Int32
        typeof(Test1).GetMethod("addNumber").Invoke(test, 
                              new object[] { (int)a, (int)b }); 
    }
