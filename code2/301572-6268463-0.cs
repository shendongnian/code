    private MyEventHandler handler;
    public event MyEventHandler MyEvent {
        add {
            handler += value;
            Trace.WriteLine("MyEvent handler attached.");
        }
        remove {
            handler -= value;
            Trace.WriteLine("MyEvent handler removed.");
        }
    }
