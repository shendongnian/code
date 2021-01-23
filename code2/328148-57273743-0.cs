					for (int rowIndex = wks.Dimension.Start.Row; rowIndex <= wks.Dimension.End.Row; rowIndex++)
					{
						var row = wks.Row(rowIndex);
						try
						{
							var s = row.Style;
						}
						catch (Exception)
						{
							row.StyleID = 0;
						}
					}
