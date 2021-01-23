    public T as<T>(object obj){
        if(obj is T)
        {
            return (T) obj;
        }
        else
        {
            return null;
        }
    }
