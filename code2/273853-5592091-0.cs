    /// <summary>
    /// Blah blah blah.
    /// </summary>
    /// <exception cref="NotSupportedException">Any use of the setter for this property.</exception>
    /// <remarks>
    /// This property is read only and should not be set.  
    /// The setter is provided for XML serialisation.
    /// </remarks>
    public virtual string IdString
    {
        get
        {
            return Id.ToString("000000");
        }
        set
        {
            throw new NotSupportedException("Setting the IdString property is not supported");
        }
    }
