    public abstract class A
    {
        protected A(string data)
        {
            Test(data);
        }
    
        private void Test(string data)
        {
            Console.WriteLine(data);
        }
    }
    
    public class B : A
    {
        public B() : base("1")
        {
            //some other initialization logic here
        }
    }
