    class MyDataType<T>
    {
        EventHandler<EventArgs> OnAdded;
    
        private RaiseOnAdded() 
        {
            var onAdded = OnAdded
            if(onAdded != null) 
            {
               onAdded(this, new EventArgs());
            } 
        }
        private List<T> data;
        ...
        public void Add(T value)
        {
            data.Add(value);
            RaiseOnAdded(); // <-- Add knows to call OnAdded(..) 
        }
        ...
    }
    
    var hander = (s, e)=>Console.WriteLine("OnAdd"));
    
    MyDataTypeObject.OnAdded  += handler;
    
    MyDataTypeObject.OnAdded  -= handler;
