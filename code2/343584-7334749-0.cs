    /// <summary>
    /// Sets data associated with the instance using the default media type.
    /// </summary>
    /// <param name="key">The key defining the data.</param>
    /// <param name="value">The data.</param>
    public void SetData(object key, object value)
    {
        SetData(key, value, null);
    }
    /// <summary>
    /// Sets data associated with the instance using the specified media type.
    /// </summary>
    /// <param name="key">The key defining the data.</param>
    /// <param name="value">The data.</param>
    /// <param name="mime">The media type of the data.</param>
    public void SetData(object key, object value, string mime)
    {
        ...
    }
