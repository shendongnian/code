C#
public class ModifiedList<example_of_stored_class> 
    : AdvancedList<example_of_stored_class>
This will compile:
    public class ModifiedList<T> : AdvancedList<example_of_stored_class>
    {
        public void someMethod()
        {
        }
    }
But I suspect that you really want `ModifiedList<T>` to inherit from an `AdvancedList<T>` with the *same* type parameter:
    public class ModifiedList<MyT> : AdvancedList<MyT>
    {
        public void someMethod()
        {
        }
    }
Or else this -- you want example_of_stored_class to be the only type parameter in the picture. I that case, ModifiedList isn't generic. It's inheriting from a "realized" generic class, one that already has a type parameter supplied. 
    public class ModifiedList : AdvancedList<example_of_stored_class>
    {
        public void someMethod()
        {
        }
    }
