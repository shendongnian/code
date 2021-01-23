    //Added these to the interface.
    [DispId(aNumber)]
    void SetField(int index, string value);
    [DispId(aNumber)]
    void SetFields(ref string[] fields);
    //Added these two methods to the class,
    //and removed the set accessor from the Fields property
    /// <summary>
    /// Set a field at the given index with a given value.
    /// </summary>
    /// <param name="index">Zero-based index of the field to set.</param>
    /// <param name="value">The value to set the field with.</param>
    public void SetField(int index, string value)
    {
        if (_fieldSizes[0][0] == -1 ||
                (value.Length > _fieldSizes[index][0] && value.Length < _fieldSizes[index][1]))
            _fields[index] = value.ToCharArray();
        else
            throw new ArgumentException("value", "Attempt to set a field with a value longer or shorter than the expected length.");
    }
    /// <summary>
    /// Sets all the fields with the values in an array.
    /// </summary>
    /// <param name="fields">An array of strings containing the values.</param>
    public void SetFields(ref string[] fields)
    {
        for (int i = 0; i < fields.Length; i++)
            SetField(i, fields[i]);
    }
