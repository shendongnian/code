    /// <summary>
    /// Safely converts a <see cref="float"/> to an <see cref="int"/> for floating-point comparisons.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct FloatToInt : IEquatable<FloatToInt>, IEquatable<float>, IEquatable<int>, IComparable<FloatToInt>, IComparable<float>, IComparable<int>
    {
    	/// <summary>
    	/// Initializes a new instance of the <see cref="FloatToInt"/> class.
    	/// </summary>
    	/// <param name="floatValue">The <see cref="float"/> value to be converted to an <see cref="int"/>.</param>
    	public FloatToInt(float floatValue)
    		: this()
    	{
    		FloatValue = floatValue;
    	}
    
    	/// <summary>
    	/// Gets the floating-point value as an integer.
    	/// </summary>
    	[FieldOffset(0)]
    	public readonly int IntValue;
    
    	/// <summary>
    	/// Gets the floating-point value.
    	/// </summary>
    	[FieldOffset(0)]
    	public readonly float FloatValue;
    
    	/// <summary>
    	/// Indicates whether the current object is equal to another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public bool Equals(FloatToInt other)
    	{
    		return other.IntValue == IntValue;
    	}
    
    	/// <summary>
    	/// Indicates whether the current object is equal to another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public bool Equals(float other)
    	{
    		return IntValue == new FloatToInt(other).IntValue;
    	}
    
    	/// <summary>
    	/// Indicates whether the current object is equal to another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public bool Equals(int other)
    	{
    		return IntValue == other;
    	}
    
    	/// <summary>
    	/// Compares the current object with another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public int CompareTo(FloatToInt other)
    	{
    		return IntValue.CompareTo(other.IntValue);
    	}
    
    	/// <summary>
    	/// Compares the current object with another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public int CompareTo(float other)
    	{
    		return IntValue.CompareTo(new FloatToInt(other).IntValue);
    	}
    
    	/// <summary>
    	/// Compares the current object with another object of the same type.
    	/// </summary>
    	/// <returns>
    	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
    	/// </returns>
    	/// <param name="other">An object to compare with this object.</param>
    	public int CompareTo(int other)
    	{
    		return IntValue.CompareTo(other);
    	}
    
    	/// <summary>
    	/// Indicates whether this instance and a specified object are equal.
    	/// </summary>
    	/// <returns>
    	/// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
    	/// </returns>
    	/// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
    	public override bool Equals(object obj)
    	{
    		if (ReferenceEquals(null, obj))
    		{
    			return false;
    		}
    		if (obj.GetType() != typeof(FloatToInt))
    		{
    			return false;
    		}
    		return Equals((FloatToInt)obj);
    	}
    
    	/// <summary>
    	/// Returns the hash code for this instance.
    	/// </summary>
    	/// <returns>
    	/// A 32-bit signed integer that is the hash code for this instance.
    	/// </returns>
    	/// <filterpriority>2</filterpriority>
    	public override int GetHashCode()
    	{
    		return IntValue;
    	}
    
    	/// <summary>
    	/// Implicitly converts from a <see cref="FloatToInt"/> to an <see cref="int"/>.
    	/// </summary>
    	/// <param name="value">A <see cref="FloatToInt"/>.</param>
    	/// <returns>An integer representation of the floating-point value.</returns>
    	public static implicit operator int(FloatToInt value)
    	{
    		return value.IntValue;
    	}
    
    	/// <summary>
    	/// Implicitly converts from a <see cref="FloatToInt"/> to a <see cref="float"/>.
    	/// </summary>
    	/// <param name="value">A <see cref="FloatToInt"/>.</param>
    	/// <returns>The floating-point value.</returns>
    	public static implicit operator float(FloatToInt value)
    	{
    		return value.FloatValue;
    	}
    
    	/// <summary>
    	/// Determines if two <see cref="FloatToInt"/> instances have the same integer representation.
    	/// </summary>
    	/// <param name="left">A <see cref="FloatToInt"/>.</param>
    	/// <param name="right">A <see cref="FloatToInt"/>.</param>
    	/// <returns>true if the two <see cref="FloatToInt"/> have the same integer representation; otherwise, false.</returns>
    	public static bool operator ==(FloatToInt left, FloatToInt right)
    	{
    		return left.IntValue == right.IntValue;
    	}
    
    	/// <summary>
    	/// Determines if two <see cref="FloatToInt"/> instances have different integer representations.
    	/// </summary>
    	/// <param name="left">A <see cref="FloatToInt"/>.</param>
    	/// <param name="right">A <see cref="FloatToInt"/>.</param>
    	/// <returns>true if the two <see cref="FloatToInt"/> have different integer representations; otherwise, false.</returns>
    	public static bool operator !=(FloatToInt left, FloatToInt right)
    	{
    		return !(left == right);
    	}
    }
