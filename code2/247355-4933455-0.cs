    int? biggestColumnIndex = 0;
    foreach (Row row in rows) 
    {
       if (row.Descendants<Cell>().Any())
       {
          // Figure out the if this row has a bigger column index than the previous rows
          int? columnIndex = GetColumnIndexFromName(((Cell)(row.LastChild)).CellReference);
          biggestColumnIndex = columnIndex.HasValue && columnIndex > biggestColumnIndex ?  columnIndex : biggestColumnIndex;                   
       }
    }
            /// <summary>
    		/// Given just the column name (no row index), it will return the zero based column index.
    		/// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
    		/// A length of three can be implemented when needed.
    		/// </summary>
    		/// <param name="columnName">Column Name (ie. A or AB)</param>
    		/// <returns>Zero based index if the conversion was successful; otherwise null</returns>
    		public static int? GetColumnIndexFromName(string columnName)
    		{
    			int? columnIndex = null;
    
    			string[] colLetters = Regex.Split(columnName, "([A-Z]+)");
    			colLetters = colLetters.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    
    			if (colLetters.Count() <= 2)
    			{
    				int index = 0;
    				foreach (string col in colLetters)
    				{
    					List<char> col1 = colLetters.ElementAt(index).ToCharArray().ToList();
    					int? indexValue = Letters.IndexOf(col1.ElementAt(index));
    
    					if (indexValue != -1)
    					{
    						// The first letter of a two digit column needs some extra calculations
    						if (index == 0 && colLetters.Count() == 2)
    						{
    							columnIndex = columnIndex == null ? (indexValue + 1) * 26 : columnIndex + ((indexValue + 1) * 26);
    						}
    						else
    						{
    							columnIndex = columnIndex == null ? indexValue : columnIndex + indexValue;
    						}
    					}
    
    					index++;
    				}
    			}
    
    			return columnIndex;
    		}
    
