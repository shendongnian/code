public static class IntegerExtensions
{
    public static Boolean IsNonZeroMultipleOf( this Int32 value, Int32 divisor)
    {
        return ( value > 0 ) && ( value % divisor ) == 0;
    }
}
Usage:
if( Settings.Trk3.IsNonZeroMultipleOf( 20 ) )
{
    // Do something.
}
Regarding performance: the JIT should be smart-enough to inline trivial _non-virtual_ method-calls, especially to _pure functions_, including extension methods, so it's safe to use this code in a tight-loop if absolutely necessary. (I don't think using the `[Pure]` attribute is necessary).
However, if you want to be an absolutely horrible programmer then use a custom struct with implicit conversion to/from `Int32` and an overloaded operator. This code (abuses) the `>>` operator to perform the same `IsNonZeroMultipleOf` operation described above. (At least by using `>>` it's more obvious to users that something odd is going on instead of overloading the `%` operator):
public struct MyInteger
{
    private readonly Int32 value;
    public MyInteger( Int32 value )
    {
        this.value = value;
    }
    public static implicit operator Int32( MyInteger mi ) => mi.value;
    public static explicit operator MyInteger( Int32 value ) => new MyInteger( value );
    public static Boolean operator >>(MyInteger value, Int32 divisor)
    {
        return ( value.value > 0 ) && ( value.value % divisor ) == 0;
    }
}
Usage:
MyInteger mi = Settings.Trk3;
if( mi >> 20 )
{
    // Do something.
}
