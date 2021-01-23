    public class AnimalTestClass : Animal
    {
         public bool BarkCalled{get;set;}
         public override string Bark()
         {
              BarkCalled = true;
              return base.Bark();
         }
    }
