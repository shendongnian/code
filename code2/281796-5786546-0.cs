    class Program
    {
       static void Main(string[] args)    
       {
           Program p = new Program();
           ThreadPool.QueueUserWorkItem(o => p.print("hello"));
           Console.ReadLine();
       }
       public void print(string s)
       {
          Console.WriteLine(s);    
       }
    }
