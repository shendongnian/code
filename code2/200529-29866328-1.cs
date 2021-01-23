    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<CaseSensitiveAttribute, bool>(
                    "CaseSensitive",
                    (property, attributes) => attributes.Single().IsEnabled));
            base.OnModelCreating(modelBuilder);
        }
