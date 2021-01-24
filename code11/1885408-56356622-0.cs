    public DataTable GetBLLDataTable()
    {
		switch(foo)
		{
			case bar:
				return BLL.GetDataTable(bar);
				break;
			default:
				return BLL.GetDataTable();
				break;
		}
	}
