	public DataObjectMapping()
	{
		Table("DataObjects");
		Id(x => x.ObjectID).Column("ObjectID");
		HasMany(x => x.Properties).KeyColumn("ObjectID");
	}
