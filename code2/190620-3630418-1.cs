The interface property is still public, so the serializer will still attempt to serialize it (and crash).
Put an XmlIgnore attribute on the interface property like this:
    [XmlIgnore]
    [HasMany(typeof(CustomerAddress), ColumnKey = "CustomerId", Table = "Customer")]
    public virtual IList<CustomerAddress> CustomerAddresses
    {
        get
        {
            return this._customerAddresses;
        }
        set
        {
            this._customerAddresses = value;
        }
    }
You List implementation is screwed up also.  Add this declaration right below your IList&lt;CustomerAddress&gt; property declaration:
    public List<CustomerAddress> CustomerAddresses
    {
        get
        {
            return (List<CustomerAddress>)this._customerAddresses;
        }
        set
        {
            this._customerAddresses = value;
        }
    }
