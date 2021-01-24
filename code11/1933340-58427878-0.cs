c#
public class Example
{
    // this is a class variable, this variable is now reachable from outside the class 
    // definition.
    public int aClassVariable;
    
    // this is a class property which because we added the get and set calls generate 
    // automatically an get and set method (internally)
    public bool aClassProperty { get; set; }
    
    public Example()
    {
        // to set the class variable and property you just give them a value.
        aClassVariable = 42;
        aClassProperty = true;
        // this variable is not available outside the scope of this function, 
        // this is because you declared the variable inside this function.
        // So the variable is only available inside this function as long as this 
        // function runs (or as it is called "is in scope").
        int[] arr = new int[10]; 
    }
}
Also pay attention about the differences between variables and properties, a variable is something every OOP language contains.
But the properties are actually an extension for the variables where the accessing and setting can be modified with a definition of the get and set method.
I would strongly suggest to read the documentation linked from the answer of [TheGeneral](https://stackoverflow.com/a/58427247/3091461) because it contains far more information about the intricacies of OOP and C# itself.
