    public void Export_to_Excel(DataGridView dgv, string file_name)
            {
    
                String file_path= Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\" +file_name + ".xlsx";
    
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
                    saveFileDialog.Filter = "Excel Workbook |*.xlsx";
                    saveFileDialog.Title = "Save as";
                    saveFileDialog.FileName = file_name;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        file_path = saveFileDialog.FileName;                  
                    }
                    else
                    {
                        return;
                    }
                }
    
                using (var workbook = SpreadsheetDocument.Create(file_path, SpreadsheetDocumentType.Workbook))
                {
                    var workbookPart = workbook.AddWorkbookPart();
    
                    workbook.WorkbookPart.Workbook = new Workbook();
                    workbook.WorkbookPart.Workbook.Sheets = new Sheets();
    
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
         
                    //Autofit comes first – we calculate width of columns based on data
                    sheetPart.Worksheet = new Worksheet();
                    sheetPart.Worksheet.Append(AutoFit_Columns(dgv));
                    sheetPart.Worksheet.Append(sheetData);
    
                    //Adding styles to worksheet
                    Worksheet_Style(workbook);
    
                    Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);
    
                    uint sheetId = 1;
                    if (sheets.Elements<Sheet>().Count() > 0)
                    {
                        sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }
    
                    Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = "List " + sheetId };
                    sheets.Append(sheet);
    
                    Row headerRow = new Row(); //Adding column headers
    
                    for (int col = 0; col < dgv.ColumnCount; col++)
                    {
                        Cell cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(dgv.Columns[col].HeaderText),
                            StyleIndex = 1// bold font
                        };
                        headerRow.AppendChild(cell);
                    }
    
                    // Add the row values to the excel sheet 
                    sheetData.AppendChild(headerRow);
    
                    for (int row = 0; row < dgv.RowCount; row++)
                    {
                        Row newRow = new Row();
    
                        for (int col = 0; col < dgv.ColumnCount; col++)
                        {
                            Cell cell = new Cell();
    
                            //Checking types of data
                           // I had problems here with Number format, I just can't set It to a
                          // Datatype=CellValues.Number. If someone knows answer please let me know. However, Date format strangely works fine with Number datatype ?
                         // Also important – whatever format you define in creating stylesheets, you have to insert value of same kind in string here – for CellValues !
                        // I used cell formating as I needed, for something else just change Worksheet_Style method to your needs
                            if (dgv.Columns[col].ValueType == typeof(decimal)) //numbers
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.String);
                                cell.CellValue = new CellValue(((decimal)dgv.Rows[row].Cells[col].Value).ToString("#,##0.00"));
                                cell.StyleIndex = 3;
                            }
                            else if (dgv.Columns[col].ValueType == typeof(DateTime)) //dates
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                cell.CellValue = new CellValue(((DateTime)dgv.Rows[row].Cells[col].Value).ToOADate().ToString(CultureInfo.InvariantCulture));
                                cell.StyleIndex = 2;
                            }
                            Else // strings
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.String);
                                cell.CellValue = new CellValue(dgv.Rows[row].Cells[col].Value.ToString());
                                cell.StyleIndex = 0;
                            }
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                    }
                }
    
            }
    
            private static WorkbookStylesPart Worksheet_Style (SpreadsheetDocument document)
            {
                WorkbookStylesPart create_style = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                Stylesheet workbookstylesheet = new Stylesheet();
    
                DocumentFormat.OpenXml.Spreadsheet.Font font0 = new DocumentFormat.OpenXml.Spreadsheet.Font(); // Default font
                FontName arial = new FontName() { Val = "Arial" };
                FontSize size = new FontSize() { Val = 10 };
                font0.Append(arial);
                font0.Append(size);
               
    
                DocumentFormat.OpenXml.Spreadsheet.Font font1 = new DocumentFormat.OpenXml.Spreadsheet.Font(); // Bold font
                Bold bold = new Bold();
                font1.Append(bold);
     
                // Append both fonts
                Fonts fonts = new Fonts();     
                fonts.Append(font0);
                fonts.Append(font1);
    
                //Append fills - a must, in my case just default
                Fill fill0 = new Fill();        
                Fills fills = new Fills();      
                fills.Append(fill0);
    
                // Append borders - a must, in my case just default
                Border border0 = new Border();     // Default border
                Borders borders = new Borders();    
                borders.Append(border0);
    
                // CellFormats
                CellFormats cellformats = new CellFormats();
    
                CellFormat cellformat0 = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }; // Default style : Mandatory | Style ID =0
                CellFormat bolded_format = new CellFormat() { FontId = 1 };  // Style with Bold text ; Style ID = 1
                CellFormat date_format = new CellFormat() { BorderId = 0, FillId = 0, FontId = 0, NumberFormatId = 14, FormatId = 0, ApplyNumberFormat = true };
                CellFormat number_format = new CellFormat() { BorderId = 0, FillId = 0, FontId = 0, NumberFormatId = 4, FormatId = 0, ApplyNumberFormat = true }; // format like "#,##0.00"
    
                cellformats.Append(cellformat0);
                cellformats.Append(bolded_format);
                cellformats.Append(date_format);
                cellformats.Append(number_format);
                        
                // Append everyting to stylesheet  - Preserve the ORDER !
                workbookstylesheet.Append(fonts);
                workbookstylesheet.Append(fills);
                workbookstylesheet.Append(borders);
                workbookstylesheet.Append(cellformats);
    
                //Save style for finish
                create_style.Stylesheet = workbookstylesheet;
                create_style.Stylesheet.Save();
    
                return create_style;
            }
          
    
            private Columns AutoFit_Columns(DataGridView dgv)
            {
                Columns cols = new Columns();
                int Excel_column=0;
    
                DataTable dt = new DataTable();
                dt = (DataTable)dgv.DataSource;
    
                for (int col = 0; col < dgv.ColumnCount; col++)
                {
                    double max_width = 14.5f; // something like default Excel width, I'm not sure about this
                  
                    //We search for longest string in each column and convert that into double to get desired width 
                    string longest_string = dt.AsEnumerable()
                         .Select(row => row[col].ToString())
                         .OrderByDescending(st => st.Length).FirstOrDefault();
                            
                    double cell_width = GetWidth(new System.Drawing.Font("Arial", 10), longest_string);
                                 
                    if (cell_width > max_width)
                    {
                        max_width = cell_width;
                    }
    
                    if (col == 0) //first column of Datagridview is index 0, but there is no 0 index of column in Excel, careful with that !!!
                    {
                        Excel_column = 1;
                    }
    
                    //now append column to worksheet, calculations done
                    Column c = new Column() { Min = Convert.ToUInt32(Excel_column), Max = Convert.ToUInt32(Excel_column), Width = max_width, CustomWidth = true };
                    cols.Append(c);
                                   
                    Excel_column++;
                }
                return cols;
            }
       
            private static double GetWidth(System.Drawing.Font stringFont, string text)
            {
                // This formula calculates width. For better desired outputs try to change 0.5M to something else
    
                Size textSize = TextRenderer.MeasureText(text, stringFont);
                double width = (double)(((textSize.Width / (double)7) * 256) - (128 / 7)) / 256;
                width = (double)decimal.Round((decimal)width + 0.5M, 2);
    
                return width;
            }
