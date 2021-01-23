    foreach (Column column in ColumnIterator)
			{
				IColumnMetadata columnInfo = tableInfo.GetColumnMetadata(column.Name);
				if (columnInfo != null)
				{
					continue;
				}
				// the column doesnt exist at all.
				// other not important code
			}
