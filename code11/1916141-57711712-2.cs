    public void AssignPropertyChangedMethod(string methodName)
    {
        var methodInfo = this.GetType().GetMethod(methodName);
        var handler = Delegate.CreateDelegate(typeof(PropertyChangedEventHandler), this, methodInfo);
        myData.PropertyChanged += handler;
    }
