	public override Array /* RuntimeType.*/ GetEnumValues()
	{
		if (!this.IsEnum)
			throw new ArgumentException();
		ulong[] values = Enum.InternalGetValues(this);
		Array array = Array.UnsafeCreateInstance(this, values.Length);
		for (int i = 0; i < values.Length; i++)
		{
			var obj = Enum.ToObject(this, values[i]);   // ew. boxing.
			array.SetValue(obj, i);                     // yuck
		}
		return array;              // Array of object references, bleh.
	}
