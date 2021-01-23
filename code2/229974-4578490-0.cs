    ProductMap.cs
            HasMany(p => p.Stories)
                .KeyColumn("ProductOwner_id")
                .Inverse();
    SprintMap.cs
            HasMany(s => s.Stories)
                .KeyColumn("SprintOwner_id")
                ;
    CardMap.cs
            References(c=>c.Product)
                .Column("Product_id")
                .Not.Nullable();
            References(c=>c.Sprint)
                .Column("Sprint_id")
                .Nullable();
