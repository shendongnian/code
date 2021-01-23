     public event Action OnDataChanged;
     protected object _data = null;
     public object Data
     {
         get { return _data; }
         set
         {
             _data = value;
             if(OnDataChanged != null)
                OnDataChanged();
         }
     }
