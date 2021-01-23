        [List(1, Name = "Product", Table = "Product", Cascade = CascadeStyle.None, Lazy = false, Fetch = CollectionFetchMode.Select)]
        [NHibernate.Mapping.Attributes.Key(2, Column = "categoryId")]
        [Index(3, Column = "ordinal")]
        [ManyToMany(4, ClassType = typeof(Product), Column = "productId")]
        public virtual IList<Category> Categorys
