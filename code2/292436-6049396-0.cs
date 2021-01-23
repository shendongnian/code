    if(Monitor.TryEnter(obj, new TimeSpan(0, 0, 1))) {
        try {
            body 
        }
        finally {
            Monitor.Exit(obj);
        }
    }
