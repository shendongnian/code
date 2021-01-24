    [ComVisible(true)]  
    public interface IList: ICollection, IEnumerable {  
        bool IsFixedSize {  
            get;  
        }  
        bool IsReadOnly {  
            get;  
        }  
        int Add(object value);  
        void Clear();  
      
        bool Contains(object value);  
        int IndexOf(object value);  
        void Insert(int index, object value);  
        void Remove(object value);  
        void RemoveAt(int index);  
    }  
