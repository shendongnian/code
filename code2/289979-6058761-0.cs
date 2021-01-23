    public class Animal{}
    public class G<T> where T : Animal
    {
         public T GetT()
         {
           return new Animal();
         }
    }
    Fish fish = new G<Fish>().GetT();
