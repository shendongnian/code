    // This list tracks the handlers, so you can
    // remove them if you're no longer interested in receiving notifications.
    //  It can be ommitted if you prefer.
    List<EventHandler<PropertyChangedEventArgs>> changedHandlers =
        new List<EventHandler<PropertyChangedEventArgs>>();
    
    // Call this method to add children to the parent
    public void AddChild(MyChild newChild)
    {
        // Omitted: error checking, and ensuring newChild isn't already in the list
        this.MyChildren.Add(newChild);
        EventHandler<PropertyChangedEventArgs> eh =
            new EventHandler<PropertyChangedEventArgs>(ChildChanged);
        newChild.PropertyChanged += eh;
        this.changedHandlers.Add(eh);
    }
    
    public void ChildChanged(object sender, PropertyChangedEventArgs e)
    {
        MyChild child = sender as MyChild;
        if (this.MyChildren.Contains(child))
        {
            RaiseChanged("IsChanged");
        }
    }
