        //We declare delegates as a new type outside of any class scope (can be also inside?)
            public delegate retType TypeName (params...)
        //Here we assign
            public TypeName concreteDeleagteName = new TypeName (specificMethodName);
        //Declaring event
        //a. taken from http://stackoverflow.com/questions/2923952/explicit-event-add-remove-misunderstood
        private EventHandler _explicitEvent;
        public event EventHandler ExplicitEvent
        {
           add
           {
               if (_explicitEvent == null) timer.Start();
               _explicitEvent += value;
           }
           remove
           {
              _explicitEvent -= value;
              if (_explicitEvent == null) timer.Stop();
           }
        }
        //or: b.auto event - the compiler creates a "hidden" delegate which is bounded to this event
              public event TypeName eventName;
