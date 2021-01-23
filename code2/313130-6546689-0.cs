    // Catch SIGINT and SIGUSR1
    UnixSignal[] signals = new UnixSignal [] {
        new UnixSignal (Mono.Unix.Native.Signum.SIGINT),
        new UnixSignal (Mono.Unix.Native.Signum.SIGUSR1),
    };
     
    Thread signal_thread = new Thread (delegate () {
        while (true) {
            // Wait for a signal to be delivered
            int index = UnixSignal.WaitAny (signals, -1);
     
            Mono.Unix.Native.Signum signal = signals [index].Signum;
     
            // Notify the main thread that a signal was received,
        	// you can use things like:
        	//    Application.Invoke () for Gtk#
        	//    Control.Invoke on Windows.Forms
        	//    Write to a pipe created with UnixPipes for server apps.
        	//    Use an AutoResetEvent
         
        	// For example, this works with Gtk#	
        	Application.Invoke (delegate () { ReceivedSignal (signal); }
        });
