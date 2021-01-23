    public static class DataExtensions
    {
    	public static IEnumerable<IEnumerable<DataRow>> Partition(this DataTable dataTable, int partitionSize)
    	{
    		var numRows = Math.Ceiling((double)dataTable.Rows.Count);
    		for(var i = 0; i < numRows / partitionSize; i++)
    		{
    			yield return Partition(dataTable, i * partitionSize, i * partitionSize + partitionSize);
    		}
    	}
    	private static IEnumerable<DataRow> Partition(DataTable dataTable, int index, int endIndex)
    	{
    		for(var i = index; i < endIndex && i < dataTable.Rows.Count; i++)
    		{
    			yield return dataTable.Rows[i];
    		}
    	}
    }
    var partitions = dataTable.Partition(100);
