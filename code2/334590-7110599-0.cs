    #region Property - Name
    private string _name;
    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    /// <remarks>
    /// This should always be the full name of the customer in the format {First Name} {Last Name}.
    /// </remarks>
    /// <example>
    /// customer.Name = "Joe Bloggs";
    /// </example>
    /// <seealso cref="Customer"/>
    /// <value>
    /// The name of the customer.
    /// </value>
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    #endregion
