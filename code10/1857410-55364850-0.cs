            internal ImportFormulaSheetResponse ImportFormulaSheet(string formulaFilePath)
            {
            	var impFormRes = new ImportFormulaSheetResponse();
            
            	try
            	{
            		using (var workbookFormula = new ExcelPackage(new FileInfo(formulaFilePath)))
            		using (var workbookOriginal = CreateExcelPackage(this.Stream))
            		{
            			List<string> sheetNames = new List<string>();
            			List<string> formulaSheets = new List<string>();
            
            			foreach (var worksheet in workbookOriginal.Workbook.Worksheets)
            			{
            				List<int> parameterCols = new List<int> { 1, 2, 17 };
            
            				int rowCount = worksheet.Dimension.End.Row;
            				foreach(int col in parameterCols)
            				{
            					for (int row = 14; row < rowCount; row++)
            					{
            						if (worksheet.Cells[row, col].IsRichText)
            						{
            							//removing super/sub script formatting from RichText Cell property
            							var celVal = worksheet.Cells[row, col].Value;
            							if (worksheet.Cells[row, col].Merge == true)
            							{
            								string range = GetMergedRange(worksheet, row, col);
            								worksheet.Cells[range].Merge = false;
            							}
            							worksheet.Cells[row, col].Clear();
            							worksheet.Cells[row, col].Value = celVal;
            						}
            					}
            				}
            			}
            
            			foreach (var worksheet in workbookFormula.Workbook.Worksheets)
            			{
            				if (worksheet.Name.Contains("Formula"))
            				{
            					workbookOriginal.Workbook.Worksheets.Add(worksheet.Name, worksheet);
            					formulaSheets.Add(worksheet.Name);
            				}
            				else
            				{
            					sheetNames.Add(worksheet.Name);
            				}
            			}
            
            			//Calculate so the formula references have updated values
            			workbookOriginal.Workbook.Calculate();
            			workbookOriginal.Save();
            			this.Stream = workbookOriginal.Stream;
            
            			return impFormRes;
            		}
            	}
            	catch (Exception ex)
            	{
            		impFormRes.Notifications.AddError(ex.Source, ex.Message);
            		return impFormRes;
            	}
            }
            
            /// <summary>
            /// Find the merged range a specific cell it belongs to
            /// </summary>
            /// <returns>merged cell string</returns>
            internal string GetMergedRange(ExcelWorksheet worksheet, int row, int col)
            {
            	ExcelWorksheet.MergeCellsCollection mergedCells = worksheet.MergedCells;
            	foreach (var merged in mergedCells)
            	{
            		ExcelRange range = worksheet.Cells[merged];
            		ExcelCellAddress cell = new ExcelCellAddress(row, col);
            		if (range.Start.Row <= cell.Row && range.Start.Column <= cell.Column)
            		{
            			if (range.End.Row >= cell.Row && range.End.Column >= cell.Column)
            			{
            				return merged.ToString();
            			}
            		}
            	}
            	return "";
            }
        
    /////////////////////////////////////////////////////////////////
    
        public class ExcelImport
        {
        	//workbook.Calculate() generates xml style tag around a cell with multiple styling
        	//so add root tag to make it a proper xml document, parse and read root value
        	if (rowData[2].Contains("<"))
        	{
        		string myXML = "<root>" + rowData[2] + "</root>";
        		XDocument doc = XDocument.Parse(myXML);
        		InstrumentName = doc.Root.Value;
        	}
        }
