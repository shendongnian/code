    public class NotifyPropertyChangedWrapper<T> 
        : DynamicObject, INotifyPropertyChanged
    {
        private T _obj;
    
        public NotifyPropertyChangedWrapper(T obj)
        {
            _obj = obj;
        }
    
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            result = typeof(T).GetProperty(binder.Name).GetValue(_obj);
            return true;
        }
        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            typeof(T).GetProperty(binder.Name).SetValue(_obj, value);
            OnPropertyChanged(binder.Name);
            return true;
        }
        
        // Implement OnPropertyChanged...
    }
