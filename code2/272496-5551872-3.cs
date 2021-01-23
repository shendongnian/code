    public class BoomBoxJogger : IMusicalJogger
    {
       public void IRunner.Run() //implementation of the runner aspect
       {
          Console.WriteLine("Running through the park");
       }
       public void IRunnable.Run() //implementation of the runnable aspect
       {
          Console.WriteLine("Blasting out Megadeth on my boombox");
       }
       public void Run() //a new method defined in the class itself 
       {
          Console.WriteLine("Running while listening to music");
       }
   
    }
