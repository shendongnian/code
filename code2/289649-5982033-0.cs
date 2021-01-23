    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program(); // dependency of the class will be there.So not a good practice
            p.RealMain();// if you want initalize, you have to go like this or better you can do it in some other class.
        }
    
        void RealMain(){} 
    }
