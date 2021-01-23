    class EventArgsX : EventArgs {
            public IEnumerable<object> YourCollection { get; set; }
    }
    instance.SomeEvent += (s, args) => {
       foreach(object O in args.YourCollection){
          //do something
       }
    }
