    public class Program{
       
       public delegate void SayHello();
       public void SayHelloAndWait(){
          Console.WriteLine("HELLO..");
          System.Threading.Thread.Sleep(5000);
          Console.WriteLine("..WORLD!");
       }
       public void SayHi(){
          Console.WriteLine("Hi world!");
       }
       public void Run(){
          SayHello helloMethods;
          helloMethods = SayHelloAndWait;
          helloMethods += SayHi;
          foreach(SayHello hello in helloMethods.GetInvocationList())
             hello.BeginInvoke(null,null);
       }
       public static void Main(String[] args){
          new Program().Run();
          Console.Read();
       }
       
    }
