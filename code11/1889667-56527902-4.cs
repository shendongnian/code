	IEnumerable<System.Drawing.Color?> colList = getColors(1);
    // System.Drawing.Color is not nullable:
	foreach (System.Drawing.Color col in colList)
	{
		Console.WriteLine(col);
	}
