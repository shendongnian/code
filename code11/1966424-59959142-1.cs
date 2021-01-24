    var dataView = collectionView.SourceCollection as DataView;
    if (dataView.Table.Columns[col].DataType == typeof(string))
    {
    	var calcCol = col + "_Double";
    	if (!dataView.Table.Columns.Contains(calcCol))
    		dataView.Table.Columns.Add(calcCol, typeof(double), $"CONVERT({col}, 'System.Double')");
    	col = calcCol;
    }
    collectionView.CustomFilter = $"{col} > AVG({col})";
 
