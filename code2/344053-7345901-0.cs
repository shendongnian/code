    class BaseNotifyingClass // or maybe an interface type
    {
      // put event in here
    }
    class MyNotifyingClass : public BaseNotifyingClass
    {
      // as before, without event
    }
    class MyHandlingClass
    {
      public MyHandlingClass (BaseNotifyingClass notifier)
      {
         m_notifier = notifier;
         m_notifier.Notify += HandleNotification;
      }
      // etc...
    }
    class SomeFactory
    {
      public MyHandlingClass Create()
      { 
        var myNotifier = new MyNotifyingClass();
        var myHandler = new MyHandlingClass(myNotifier);
        return myHandler;
      }
      // etc...
    }
