    using System;
    namespace CustomEventDemo
    {
      class Program
      {
        static void Main(string[] args)
        {
          TheClassExposingYourEvent instance = new TheClassExposingYourEvent();
      
          instance.MyCustomEvent += new EventHandler<EventArgs>(Program_MyCustomEvent);
          instance.DoSomething();
          instance.MyCustomEvent -= new EventHandler<EventArgs>(Program_MyCustomEvent);
          Console.ReadKey();
        }
        static void Program_MyCustomEvent(object sender, EventArgs e)
        {
          Console.WriteLine("The event was fired");
        }
      }
      class TheClassExposingYourEvent
      {
        private EventHandler<EventArgs> _myCustomEventDelegate;
        public event EventHandler<EventArgs> MyCustomEvent
        {
          add
          {
            _myCustomEventDelegate += value;
            // Do something extra here.
            // Writing to the console is a bad example!!!
            Console.WriteLine("Event handler attached");
          }
          remove
          {
            _myCustomEventDelegate -= value;
            // Do something extra here.
            // Writing to the console is a bad example!!!
            Console.WriteLine("Event handler detached");
          }
        }
        public void DoSomething()
        {
          if (_myCustomEventDelegate != null)
          {
            _myCustomEventDelegate(this, EventArgs.Empty);
          }
        }
      }
    }
