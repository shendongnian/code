    public class ChangingPrimitive<T> : INotifyPropertyChanged
    {
        // ... implement INotifyPropertyChanged Here
    
        public T Inner {get;set;}
    
        // ... optional work to expose the inner type directly
    }
