	List<Table> SortTableList(List<Table> TableList)
	{
		List<Table> resultTable = new List<Table>();
		int tableCount = TableList.Count;
		int confirmedTableCount = 0;
		while(confirmedTableCount < tableCount)
		{
			foreach(var table in TableList)
			{
				if(resultTable.Contains(table) == true) continue;
				
				bool CanThisTableAddToResult = true;
				foreach(var child in table.ChildTables)
				{
					if(resultTable.Find(tbl => tbl.TableName == child) == null) // this table's child table doesn't exist at result table yet, so it can not be added now.
					{
						CanThisTableAddToResult = false; 
						break;
					}
				}
				
				if(CanThisTableAddToResult == true)
				{
					resultTable.Add(table);
					confirmedTableCount++;
				}
			}
		}
        return resultTable;
	}
