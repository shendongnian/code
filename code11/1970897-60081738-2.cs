    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.ComplexType<ReturnThreeColumnTableFunction>();
        modelBuilder.ComplexType<ReturnThreeColumnTableFunction>().Property(x => x.ColumnOne).HasColumnName("ColumnOne");
        modelBuilder.ComplexType<ReturnThreeColumnTableFunction>().Property(x => x.ColumnTwo).HasColumnName("ColumnTwo");
        modelBuilder.ComplexType<ReturnThreeColumnTableFunction>().Property(x => x.ColumnThree).HasColumnName("ColumnThree");
    }
