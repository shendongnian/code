    public DelegateStoreage<T>{
      
     public void Add(T del){
        //Do your stuff
    }
     public void Remove(T del){
        //Do your stuff
     }
     public static T operator +(DelegateStoreage<T> x, T y)
        {
            x.Add(y)
            return x
        }
        public static T operator -( DelegateStoreage<T> x, T y)
        {
            x.Remove(y)
            return y;
        }
    }
