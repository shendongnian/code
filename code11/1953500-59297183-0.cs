c#
public const float NaN = (float)0.0 / (float)0.0;
public static unsafe bool IsNaN(float f) => f != f;
public int CompareTo(object? value){
   ...
   if (m_value < f) return -1;
   if (m_value > f) return 1;
   if (m_value == f) return 0;
   if (IsNaN(m_value))
      return IsNaN(f) ? 0 : -1;
   else // f is NaN.
      return 1;
}
public bool Equals(float obj)
{
   if (obj == m_value)
   {
      return true;
   }
   return IsNaN(obj) && IsNaN(m_value);
}
public override int GetHashCode()
{
   int bits = Unsafe.As<float, int>(ref Unsafe.AsRef(in m_value));
   // Optimized check for IsNan() || IsZero()
   if (((bits - 1) & 0x7FFFFFFF) >= 0x7F800000)
   {
      // Ensure that all NaNs and both zeros have the same hash code
      bits &= 0x7F800000;
   }
   return bits;
}
You can see that NaN requires special handling in each of these cases. The standard IEEE representation leaves most bits undefined, and defines special cases for comparisons even if those bit values are identical. 
However you can also see that both `GetHashCode()` && `Equals()` treat two NaN's as equivalent. So I believe that using NaN as a dictionary key should be fine.
