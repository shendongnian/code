    public class MyForm : Form, IHandle<MyEvent>
    {
       public MyForm() 
       {
          SomeStaticPlace.EventAggregator.Subscribe(this); //Can be replaced with DI
       }
    
       public void Handle(MyEvent message) 
       {
          //Act on event
       }
    }
