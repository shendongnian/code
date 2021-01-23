    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    #region IEntity<Product> Members
    public Product MapData(System.Data.IDataReader reader)
    {
        return new Product
        {
            Name = reader["name"] as string,
            Description = reader["description"] as string
        };
    }
    #endregion
