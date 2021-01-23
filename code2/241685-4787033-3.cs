    StackTray st = new StackTray();
    for (int i=0; i < 10; i++) {
        st.Increment();
        Console.WriteLine("Stack: {0} Tray: {1}", st.Stack + 1, st.Tray + 1); // tada - one based
    }
    for (int i=0; i < 5; i++) {
        st.Decrement();
        Console.WriteLine("Stack: {0} Tray: {1}", st.Stack, st.Tray); // tada - zero based
    }
