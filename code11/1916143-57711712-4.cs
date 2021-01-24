    public void AssignPropertyChangedMethod(string methodName)
    {
        var methodInfo = this.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var handler = Delegate.CreateDelegate(typeof(PropertyChangedEventHandler), this, methodInfo);
        myData.PropertyChanged += (PropertyChangedEventHandler)handler;
    }
