    [global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Category", Storage="Categories", ThisKey="pkCategoryID", OtherKey="ParentCategoryID")]
    public EntitySet<Category> Categories
    {
      get
      {
        return this._Categories;
      }
      set
      {
        this._Categories.Assign(value);
      }
    }
