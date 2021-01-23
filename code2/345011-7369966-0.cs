    class MyDataType<T>
    {
        EventHandler<EventArgs> OnAdded;
    
        private List<T> data;
        ...
        public void Add(T value) // <-- Add knows to call OnAdded(..) 
        {
            data.Add(value);
            if(OnAdded != null) 
            {
               OnAdded(this, new EventArgs());
            } 
        }
        ...
    }
    
    var hander = (s, e)=>Console.WriteLine("OnAdd"));
    
    MyDataTypeObject.OnAdded  += handler;
    
    MyDataTypeObject.OnAdded  -= handler;
