    public void AddTestInstance()
    {
        tClass test = new tClass() { Name = "Test3" };
    
        MyProperty.Add(test);
        MyPublicVariable.Add(test);
        NotifyPropertyChanged("MyPublicVariable");
    }
