`
public class MyClass
{
    public int MyPublicVariable = 0;
    public int MyPublicProperty
    {
        get;
        set;
    }
}
`
Once compiled, *conceptually*, it actually ends up being similar to the following:
`
public class MyClass
{
    public int MyPublicVariable = 0;
    private int MyPublicProperty = 0;
    public int get_MyPublicProperty()
    {
        return MyPublicProperty;
    }
    public void set_MyPublicProperty( int value )
    {
        MyPublicProperty = value;
    }
}
`
A long time ago, properties were invented to be a quick and easy way to define pairs of get and set methods. It made code more readable and easier to understand as they conveyed intent and ensured consistency.
`
MyClass myClass = new MyClass();
myClass.MyPublicVariable = 2;
myClass.MyPublicProperty = 2;
`
Once compiled, again *conceptually*, it ends up being similar to the following:
`
MyClass myClass = new MyClass();
myClass.MyPublicVariable = 2;
myClass.set_MyPublicProperty( 2 );
`
So, one of the reasons for preferring public properties over public variables is if you need to use different logic as your code evolves then consumers of your code don't necessarily need to re-compile. This is why it is often considered best practice.
There has also been some comments about interfaces. Interfaces are essentially a contract that guarantees the presence of certain methods within any class implementing them. As we know from the above, properties represent one or two methods so they work just fine in interfaces.
Hope this helps a little.
Here is another example that may be of interest:
`
public class MyClass
{
    private int[] _myArray = new int[ 5 ];
    public int MyArray[ int index ]
    {
        get
        {
            return _myArray[ index ];
        }
        set
        {
            _myArray[ index ] = value;
        }
     }
}
`
`
public class MyClass
{
    private int[] _myArray = new int[ 5 ];
    public int get_MyArray( int index )
    {
        return _myArray[ index ];
    }
    public void set_MyArray( int index, int value )
    {
        _myArray[ index ] = value;
    }
}
`
> Please note: I cannot exactly remember the method signatures used when decompiling
> properties. I think it is 'get_XXX' and 'set_XXX' but it could be
> something else that is very similar. As long as the understanding is there,
> it probably doesn't matter too much. In the end, they all become memory addresses anyway :-)
