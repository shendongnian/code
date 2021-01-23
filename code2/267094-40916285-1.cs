    public Facility Bind(IDataReader reader)
    {
    	var x = new Facility();
    	x.ID = reader.ReadAs<Guid>("ID");
    	x.Name = reader.ReadAs<string>("Name");
    	x.Capacity = reader.ReadAs<int?>("Capacity");
    	x.Description = reader.ReadAs<string>("Description");
    	x.Address = reader.ReadAs<string>("Address");
    	return x;
    }
