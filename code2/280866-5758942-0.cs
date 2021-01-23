/// &lt;summary>
/// AreClose - Returns whether or not two doubles are "close".  That is, whether or 
/// not they are within epsilon of each other.  Note that this epsilon is proportional
/// to the numbers themselves to that AreClose survives scalar multiplication.
/// There are plenty of ways for this to return false even for numbers which
/// are theoretically identical, so no code calling this should fail to work if this 
/// returns false.  This is important enough to repeat:
/// NB: NO CODE CALLING THIS FUNCTION SHOULD DEPEND ON ACCURATE RESULTS - this should be
/// used for optimizations *only*.
/// &lt;/summary>
/// &lt;returns>
/// bool - the result of the AreClose comparision.
/// &lt;/returns>
/// &lt;param name="value1"> The first double to compare. &lt;/param>
/// &lt;param name="value2"> The second double to compare. &lt;/param>
public static bool AreClose(double value1, double value2)
{
    // in case they are Infinities (then epsilon check does not work)
    if (value1 == value2)
    {
        return true;
    }
    
    // This computes (|value1-value2| / (|value1| + |value2| + 10.0)) &lt; DBL_EPSILON
    double eps = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * DBL_EPSILON;
    double delta = value1 - value2;
    return (-eps < delta) && (eps > delta);
}
