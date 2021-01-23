    dataset.Tables["Person"].AsEnumerable().Select(p => new Person
    {
        Id = p.Field<int>("Id"),
        Name = p.Field<string>("Name"),
        Age = p.Field<int>("Age"),
        ObjectState = ConvertRowStateToObjectState(p.RowState)
    }));
