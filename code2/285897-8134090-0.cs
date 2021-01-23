    HasMany<MyEntity>(n => n.MyDictionary)
      .AsMap<string>(
          index => index.Column("LCID").Type<int>(),
          element => element.Columns.Clear().Columns.Add("Value", col => col.Length(1000))
      .Cascade.AllDeleteOrphan();
