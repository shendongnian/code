namespace YourLibrary 
{
   public static class Util
   {
       public static void Shutdown()
       {
           // Potentially other stuff...
           // Cleanup logging
           Log.CloseAndFlush();
       }
   }
}
Then in you require your consumers to do something like this (example):
public static void Main()
{
   try
   {
      // ... whatever ...
   }
   finally
   {
      YourLibrary.Util.Shutdown();
   }
}
This design is not optimal from a usage point of view, but at least it makes things explicit.
In the end, however, there will always be situations when you cannot have your cleanup method being called (crashes, etc.), so I would suggest what Hans said in his comment: look for a different logging framework implementation (or choose a Serilog Sink that always flushes implicitly).
