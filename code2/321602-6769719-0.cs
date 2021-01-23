    public class Dog
    {
      public void Speak(){ Console.WriteLine( "Bark" ); }
    
      public static void KickDog(){ 
        Speak(); // <- Error here
      }
    }
