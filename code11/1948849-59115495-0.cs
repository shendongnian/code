    public class TheBase<T> { ... }
    // This subclass clears the list of generic parameters
    // by instantiating T with int. Thus, the subclass has 0
    // generic arguments
    public class TheSubclass : TheBase<int> { ...
    // This subclass reuses and gives a new name to the base class type argument
    // The T from the base class is named TheType here.
    // The subclass has 1 generic argument
    public class AnotherSubclass<TheType> : TheBase<TheType> { ...
    // This subclass reuses the generic argument but also introduces its own.
    // It has 2 generic arguments. 
    // Base class' T is called U here.
    public class YetAnothersubclass<U,V> : TheBase<U>
