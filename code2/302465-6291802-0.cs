    void Main()
    {
        Console.WriteLine(ContainsOnSomethingEvent()); // false
        OnSomething += (o,e) => {};
        Console.WriteLine(ContainsOnSomethingEvent()); // true
    }
    EventHandler mOnSomething;
	
    event EventHandler OnSomething {
        add { mOnSomething = (EventHandler)EventHandler.Combine(mOnSomething, value);	}
        remove { mOnSomething = (EventHandler)EventHandler.Remove(mOnSomething, value); }
    }
	
    public bool ContainsOnSomethingEvent() {
        return mOnSomething != null && mOnSomething.GetInvocationList().Length > 0;
    }
