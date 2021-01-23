    Type t = yourObject.GetType();
    
    if( t is typeof(List<OjbectType>) )   //object type is string, decimal, whatever...
    {
         // t is of type List<ObjectType>...
    }
    else if( t is typeof(IEnumerable<ObjectType>)
    {
         // t is of type IEnumerable<ObjectType>...
    }
    else
    {
        // t is some other type.
        // use reflection to find it.
    }
