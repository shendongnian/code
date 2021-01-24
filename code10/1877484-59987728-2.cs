    using System.Diagnostics.Tracing;
    using System.Collections.Generic;
    using System;
    
    namespace Demo1
    {
        [EventSource(Name = "JPBLog")]
        class MyCompanyEventSource : EventSource
        {
            public static MyCompanyEventSource Log = new MyCompanyEventSource();
    
            [Event(1, Message="{0} -> {1}", Channel = EventChannel.Admin)]
            public void Startup() { WriteEvent(1); }
    
            [Event(2, Message="{0}", Channel = EventChannel.Admin)]
            public void OpenFileStart(string fileName) { WriteEvent(2, fileName); }
    
            [Event(3, Message="OpenFileStop", Channel = EventChannel.Admin)]
            public void OpenFileStop() { WriteEvent(3); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string name = MyCompanyEventSource.GetName(typeof(MyCompanyEventSource));
                Console.WriteLine(name);
                IEnumerable<EventSource> eventSources = MyCompanyEventSource.GetSources();
                foreach(EventSource iS in eventSources){
                  Console.WriteLine(iS);
                }
                MyCompanyEventSource.Log.Startup();
                // ...
                MyCompanyEventSource.Log.OpenFileStart("SomeFile");
                // ...
                MyCompanyEventSource.Log.OpenFileStop();
            }
        }
    }
