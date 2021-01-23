    public class Bling
    {
         public Bling(List<IBreakfast> things)
         {
             things.ForEach(t => t.Eat());
         }
    }
