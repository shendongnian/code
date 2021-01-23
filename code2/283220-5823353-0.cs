    [SubSonicPrimaryKey]
    DatabaseColumn idcol = new DatabaseColumn("ID_NO", this)
    {
    	IsPrimaryKey = true,
    	DataType = DbType.Decimal,
    	IsNullable = false,
    	AutoIncrement = false,
    	IsForeignKey = false,
    	MaxLength = 15
    	//CleanName = "ID_NO" Temporarily removed. The 'CleanName' property does not exist on this class in the SubSonic3 master repo on GitHub. Did someone miss a file checkin?
    };
    Columns.Add(idcol);
