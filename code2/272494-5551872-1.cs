    public class BoomBoxJogger : IMusicalJogger
    {
       public void IRunner.Run()
       {
          Console.WriteLine("Running through the park");
       }
       public void IRunnable.Run()
       {
          Console.WriteLine("Blasting out Megadeth on my boombox");
       }
    }
