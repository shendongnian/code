    // You need to specify what you want when this method is called on a 
    // vanilla Foo object. I assume here that Foo is abstract. If not, please
    // specify desired behaviour.
    public bool Equals(Foo other)
    {
        if (other == null || other.GetType() != GetType())
            return false;
          
        // You can cache this MethodInfo..
        var equalsMethod = typeof(IEquatable<>).MakeGenericType(GetType())
                                               .GetMethod("Equals");
        return (bool)equalsMethod.Invoke(this, new object[] { other });
    }
