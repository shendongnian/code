    internal class MyClass
        {
            public void DoSomething(object data)
            {
                
                var e = new CustomEventArgs("Property")
                {
                    ExtraData = data
                };
    
                PropertyChanged?.Invoke(this, e);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
        
        }
    internal class CustomEventArgs : PropertyChangedEventArgs
        {
            public CustomEventArgs(string propertyName) : base(propertyName)
            {
            }
    
            public object ExtraData { get; set; }
        }
