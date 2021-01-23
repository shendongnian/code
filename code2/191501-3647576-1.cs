    public interface AnimalHandler
    {
       Action<Mammal> Feed{get;}
    }
    
    public class CreatedInFarAwayFromYou : AnimalHandler
    {
      private void Foo(Giraffe g) {}
      public Action<Mammal> Feed
      {
         return Foo;
      }
    }
    public class MadeByYou
    {
    
      private IEnumerable<Tiger> tigers;
      AnimalHandler handler;
      public void FeedAll()
      {
        foreach(var animal in tigers)
        {
           //You are by your reasoning at fault here. Not the dev that made CreatedInFarAwayFromYou 
           Feed(animal); 
        }
      }
    }
