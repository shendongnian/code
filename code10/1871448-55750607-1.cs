    public BasketItem(Guid id, Guid productId, DateTimeOffset addedAt, Money price) : this(id, productId, addedAt)
    {
    	Price = price;
    }
    
    /// <summary>
    /// EF constructor
    /// </summary>
    private BasketItem(Guid id, Guid productId, DateTimeOffset addedAt) : base(id)
    {
    	ProductId = productId;
    	AddedAt = addedAt;
    }
