    public static void EventSub()
    {
        // This line makes it so that cancel_handler is called when SomeEvent is fired.
        //  Since cancel_handler actually refers to DoConsoleCancelEvent, it is *that* method
        //  that will actually be run
        SomeType.SomeEvent += cancel_handler;
    }
