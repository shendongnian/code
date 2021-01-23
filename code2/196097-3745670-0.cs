    class Parent
    {
      List<Child> _children = new List<Child>();
      public Parent()
      {
        _children.Add(new Child());
        _children.Add(new Child());
        _children.Add(new Child());
        // Add handler to the child event
        foreach (Child child in _children)
        {
          child.TimerFired += Child_TimerFired;
        }
      }
      private void Child_TimerFired(object sender, EventArgs e)
      {
        // One of the child timers fired
        // sender is a reference to the child that fired the event
      }
    }
    class Child
    {
      public event EventHandler TimerFired;
      protected void OnTimerFired(EventArgs e)
      {      
        if (TimerFired != null)
        {
          TimerFired(this, e);
        }
      }
      // This is the event that is fired by your current timer mechanism
      private void HandleTimerTick(...)
      {
        OnTimerFired(EventArgs.Empty);
      }
    }
