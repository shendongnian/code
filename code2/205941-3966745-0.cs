    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    
    /// <summary>Represents a value masking an underlying value.</summary>
    [DebuggerDisplay("{ToString()}"), DebuggerStepThrough()]
    public class MaskedValue : IComparable<MaskedValue>, IComparer<MaskedValue>
    {
    
    	private string _value;
    	public string Value {
    		get { return _value; }
    		set { _value = value; }
    	}
    	private object _underlyingValue;
    	public object UnderlyingValue {
    		get { return _underlyingValue; }
    		set { _underlyingValue = value; }
    	}
    
    	/// <summary>Creates a new instance of the MaskedValue class.</summary>
    	public MaskedValue()
    	{
    		Value = "";
    		UnderlyingValue = null;
    	}
    
    	/// <summary>Creates a new instance of the MaskedValue class.</summary>
    	/// <param name="value">Value to be assigned to the MaskedValue.</param>
    	public MaskedValue(string value)
    	{
    		this.Value = value;
    	}
    
    	/// <summary>Creates a new instance of the MaskedValue class.</summary>
    	/// <param name="value">Value to be assigned to the MaskedValue.</param>
    	/// <param name="underlyingValue">Underlying value of the MaskedValue.</param>
    	public MaskedValue(string value, object underlyingValue)
    	{
    		this.Value = value;
    		this.UnderlyingValue = underlyingValue;
    	}
    
    	/// <summary>Gets a value that represents this MaskedValue.</summary>
    	public override string ToString()
    	{
    		return Value;
    	}
    
    	/// <summary>Compares two instances of MaskedValue.</summary>
    	/// <param name="x" >First MaskedValue to be compared.</param>
    	/// <param name="y">Second MaskedValue to be compared.</param>
    	/// <returns>
    	/// A 32-bit signed integer indicating the lexical relationship between the two comparands.
    	/// </returns>
    	[EditorBrowsable(EditorBrowsableState.Advanced)]
    	public int Compare(MaskedValue x, MaskedValue y)
    	{
    		return x.CompareTo(y);
    	}
    
    	/// <summary>Compares this MaskedValue to the other.</summary>
    	/// <param name="other">MaskedValue to compare this MaskedValue with.</param>
    	/// <returns>
    	/// A 32-bit signed integer indicating the lexical relationship between the two comparands.
    	/// </returns>
    	[EditorBrowsable(EditorBrowsableState.Advanced)]
    	public int CompareTo(MaskedValue other)
    	{
    		return this.Value.CompareTo(other.Value);
    	}
    }
