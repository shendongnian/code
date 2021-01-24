public static class IntegerExtensions
{
    public static Boolean IsNonZeroMultipleOf( this Int32 left, Int32 right )
    {
        return left > 0 && left % right == 0;
    }
}
Usage:
if( Settings.Trk3.IsNonZeroMultipleOf( 20 ) )
{
    // Do something.
}
