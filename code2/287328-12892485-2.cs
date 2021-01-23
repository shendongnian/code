        protected override IEnumerable WalkStates()
        {
        off:                                       // Each goto label is a state
            Console.WriteLine("off.");             // State entry actions
            yield return null;                     // This means "Wait until a 
                                                   // trigger is called"
                                                   // Ah, we got triggered! 
                                                   //   perform state exit actions 
                                                   //   (none, in this case)
            if (Trigger == PressSwitch) goto on;   // Transitions go here: 
                                                   // depending on the trigger 
                                                   // that was called, go to
                                                   // the right state
            InvalidTrigger();                      // Throw exception on 
                                                   // invalid trigger
            ...
