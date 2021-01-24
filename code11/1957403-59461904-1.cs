C#
[CannotApplyEqualityOperator]
public sealed class NonEquatable { }
public sealed class OtherClass
{
    public bool DoForbiddenStuff()
    {
        var obj1 = new NonEquatable();
        var obj2 = new NonEquatable();
        // ERROR! 'Cannot apply equality operator to type marked by CannotApplyEqualityOperatorAttribute'
        return obj1 == obj2; 
    }
}
Still waiting to see if there is a more generalized alternative.
