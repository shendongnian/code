    public class SecondClass{
      public FirstClass First{get;private set;}
      public ThirdClass Third{get; private set;}
      public void DoSomething(){
        First.Something++;
        Second.NotifySomethingHasBeenDone();
      }
    }
