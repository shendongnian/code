    using ExcelDna.Integration;
    public static class RangeTools {
    [ExcelCommand(MenuName="Range Tools", MenuText="Square Selection")]
	public static void SquareRange()
	{
		object[,] result;
		
		// Get a reference to the current selection
		ExcelReference selection = (ExcelReference)XlCall.Excel(XlCall.xlfSelection);
		// Get the value of the selection
		object selectionContent = selection.GetValue();
		if (selectionContent is object[,])
		{
			object[,] values = (object[,])selectionContent;
			int rows = values.GetLength(0);
			int cols = values.GetLength(1);
			result = new object[rows,cols];
			
			// Process the values
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (values[i,j] is double)
					{
						double val = (double)values[i,j];
						result[i,j] = val * val;
					}
					else
					{
						result[i,j] = values[i,j];
					}
				}
			}
		}
		else if (selectionContent is double)
		{
			double value = (double)selectionContent;
			result = new object[,] {{value * value}}; 
		}
		else
		{
			result = new object[,] {{"Selection was not a range or a number, but " + selectionContent.ToString()}};
		}
		
		// Now create the target reference that will refer to Sheet 2, getting a reference that contains the SheetId first
		ExcelReference sheet2 = (ExcelReference)XlCall.Excel(XlCall.xlSheetId, "Sheet2"); // Throws exception if no Sheet2 exists
		// ... then creating the reference with the right size as new ExcelReference(RowFirst, RowLast, ColFirst, ColLast, SheetId)
		int resultRows = result.GetLength(0);
		int resultCols = result.GetLength(1);
		ExcelReference target = new ExcelReference(0, resultRows-1, 0, resultCols-1, sheet2.SheetId);
		// Finally setting the result into the target range.
		target.SetValue(result);
	}
    }
