    public class SecondClass{
      public FirstClass First{get;private set;}
      public void DoSomething(){
        First.Something++;
        RaiseEvent<SomethingHasBeenDone>(this);
      }
    }
    public class ThirdClass:IHandles<SomethingHasBeenDone>{
      public void Handle(SomethingHasBeenDone @event){
        MessageBox("First has {0} something".With(@event.First.Something));
      }
    }
