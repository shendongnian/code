    interface IOption<T> {}
    
    public class None<T>:IOption<T>{}
    
    public class Some<T>:IOption<T>
    {
        public T Value {get;}
     
        public Some(T value)
        {
            Value=value;
        }
    
    }
    
