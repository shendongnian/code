    public class MyRandomBusinessClass
    {
      public BindingList<CustomMessage> LoggingList { get; private set; }
      public Action<MyRandomBusinessClass, CustomMessage> CallBackAction { get; private set; }
      public MyRandomBusinessClass(Action<MyRandomBusinessClass, CustomMessage> cba) 
      {
          LoggingList = new BindingList<CustomMessage>();
          this.CallBackAction = cba;
      }
      public void SomeLongRunningTask()
      {
        System.Threading.Thread.Sleep(5000);
        if (cba != null)
          CallBackAction(this, new CustomMessage("Completed long task!"));
      }
    }
