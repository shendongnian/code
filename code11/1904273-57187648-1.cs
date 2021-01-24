    private void Awake()
    {
        var interactionBehaviour= objectReference.GetComponent<InteractionBehaviour>();
    
        // either as Lambda Expression
        interactionBehaviour.OnContactBegin += () =>
            {
                // do something here
            };
    
        // or with a method
        // use this if you also want to be able to remove callbacks later!
        // it is always save to remove a callback before adding it
        // even if it's not there yet. Makes sure it is only added exactly once
        interactionBehaviour.OnContactBegin -= DoSomething;
        interactionBehaviour.OnContactBegin += DoSomething;
    }
    // make sure to always remove any callbacks as soon as possible or when they are not needed anymore
    private void OnDestroy()
    {
        interactionBehaviour.OnContactBegin -= DoSomething;
    }
    
    
    private void DoSomething()
    {
        // do something here
    }
