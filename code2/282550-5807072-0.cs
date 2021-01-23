    public static bool IsBoxed<T>(T item)
    {
                // If T is a value-type, it is boxed only when item is null:
                // in this case, T must be Nullable<??> and item is probably a  
                // nullable sans Value boxed to null.
        return typeof(T).IsValueType ? item == null
                   
            // Otherwise, it is boxed only if item is not a null-reference 
            // and refers to an object whose type is a value-type.
            : (item != null && item.GetType().IsValueType);
    }
