    public class Cage<C, A>
        where C : Cage<C, A>
        where A : Animal<C>
    {
        public M(A animal)
        {
            animal.SetCage(this); // Why is this illegal?
        }
    }
    class Animal<C>
    {
      public void SetCage(C c) {}
    }
    class Fish : Animal<Aquarium> {}
    class Aquarium : Cage<Aquarium, Fish> { }
