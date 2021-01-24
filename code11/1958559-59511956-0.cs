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
				foreach(var child in table.Child)
				{
					if(resultTable.Contains(child) == false) // this table can not add now.
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
