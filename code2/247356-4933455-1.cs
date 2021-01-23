    /// <summary>
    /// Inserts cells if required for a rectangular range of cells
    /// </summary>
    /// <param name="startCellReference">Upper left cell of the rectangle</param>
    /// <param name="endCellReference">Lower right cell of the rectangle</param>
    /// <param name="worksheetPart">Worksheet part to insert cells</param>
    public static void InsertCellsForCellRange(string startCellReference, string endCellReference, WorksheetPart worksheetPart)
    {
        uint startRow = GetRowIndex(startCellReference);
        uint endRow = GetRowIndex(endCellReference);
        string startColumn = GetColumnName(startCellReference);
        string endColumn = GetColumnName(endCellReference);
        // Insert the cells row by row if necessary
        for (uint currentRow = startRow; currentRow <= endRow; currentRow++)
        {
            string currentCell = startColumn + currentRow.ToString();
            string endCell = IncrementCellReference(endColumn + currentRow.ToString(), CellReferencePartEnum.Column);
            // Check to make sure all cells exist in the range; if not create them
            while (!currentCell.Equals(endCell))
            {
                if (GetCell(worksheetPart, currentCell) == null)
                {
                    InsertCell(GetColumnName(currentCell), GetRowIndex(currentCell), worksheetPart);
                }
                // Move the reference to the next cell in the range
                currentCell = IncrementCellReference(currentCell, CellReferencePartEnum.Column);
            }
        }
    }
            /// <summary>
            /// Given a cell name, parses the specified cell to get the row index.
            /// </summary>
            /// <param name="cellReference">Address of the cell (ie. B2)</param>
            /// <returns>Row Index (ie. 2)</returns>
            public static uint GetRowIndex(string cellReference)
            {
                // Create a regular expression to match the row index portion the cell name.
                Regex regex = new Regex(@"\d+");
                Match match = regex.Match(cellReference);
    
                return uint.Parse(match.Value);
            }
    
        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
    
            return match.Value;
        }
            /// <summary>
            /// Increments the reference of a given cell.  This reference comes from the CellReference property
            /// on a Cell.
            /// </summary>
            /// <param name="reference">reference string</param>
            /// <param name="cellRefPart">indicates what is to be incremented</param>
            /// <returns></returns>
            public static string IncrementCellReference(string reference, CellReferencePartEnum cellRefPart)
            {
                string newReference = reference;
    
                if (cellRefPart != CellReferencePartEnum.None && !String.IsNullOrEmpty(reference))
                {
                    string[] parts = Regex.Split(reference, "([A-Z]+)");
    
                    if (cellRefPart == CellReferencePartEnum.Column || cellRefPart == CellReferencePartEnum.Both)
                    {
                        List<char> col = parts[1].ToCharArray().ToList();
                        bool needsIncrement = true;
                        int index = col.Count - 1;
    
                        do
                        {
                            // increment the last letter
                            col[index] = Letters[Letters.IndexOf(col[index]) + 1];
    
                            // if it is the last letter, then we need to roll it over to 'A'
                            if (col[index] == Letters[Letters.Count - 1])
                            {
                                col[index] = Letters[0];
                            }
                            else
                            {
                                needsIncrement = false;
                            }
    
                        } while (needsIncrement && --index >= 0);
    
                        // If true, then we need to add another letter to the mix. Initial value was something like "ZZ"
                        if (needsIncrement)
                        {
                            col.Add(Letters[0]);
                        }
    
                        parts[1] = new String(col.ToArray());
                    }
    
                    if (cellRefPart == CellReferencePartEnum.Row || cellRefPart == CellReferencePartEnum.Both)
                    {
                        // Increment the row number. A reference is invalid without this componenet, so we assume it will always be present.
                        parts[2] = (int.Parse(parts[2]) + 1).ToString();
                    }
    
                    newReference = parts[1] + parts[2];
                }
    
                return newReference;
            }
            /// <summary>
            /// Returns a cell Object corresponding to a specifc address on the worksheet
            /// </summary>
            /// <param name="workSheetPart">WorkSheet to search for cell adress</param>
            /// <param name="cellAddress">Cell Address (ie. B2)</param>
            /// <returns>Cell Object</returns>
            public static Cell GetCell(WorksheetPart workSheetPart, string cellAddress)
            {
                return workSheetPart.Worksheet.Descendants<Cell>()
                                    .Where(c => cellAddress.Equals(c.CellReference))
                                    .SingleOrDefault();
            }
            /// <summary>
            /// Inserts a new cell at the specified colName and rowIndex. If a cell
            /// already exists, then the existing cell is returned.
            /// </summary>
            /// <param name="colName">Column Name</param>
            /// <param name="rowIndex">Row Index</param>
            /// <param name="worksheetPart">Worksheet Part</param>
            /// <returns>Inserted Cell</returns>
            public static Cell InsertCell(string colName, uint rowIndex, WorksheetPart worksheetPart)
            {
                return InsertCell(colName, rowIndex, worksheetPart, null);
            }
            /// <summary>
            /// Inserts a new cell at the specified colName and rowIndex. If a cell
            /// already exists, then the existing cells are shifted to the right.
            /// </summary>
            /// <param name="colName">Column Name</param>
            /// <param name="rowIndex">Row Index</param>
            /// <param name="worksheetPart">Worksheet Part</param>
            /// <param name="cell"></param>
            /// <returns>Inserted Cell</returns>
            public static Cell InsertCell(string colName, uint rowIndex, WorksheetPart worksheetPart, Cell insertCell)
            {
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
                string insertReference = colName + rowIndex;
    
                // If the worksheet does not contain a row with the specified row index, insert one.
                Row row;
                if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
                {
                    row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
                }
                else
                {
                    row = new Row() { RowIndex = rowIndex };
                    sheetData.Append(row);
                }
    
                Cell retCell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference.Value == colName + rowIndex);
                // If retCell is not null and we are not inserting a new cell, then just skip everything and return the cell
                if (retCell != null)
                {
                    // NOTE: if conditions are not combined because we want to skip the parent 'else when the outside 'if' is true.
                    // if retCell is not null and we are inserting a new cell, then move all existing cells to the right.
                    if (insertCell != null)
                    {
                        // Get all the cells in the row with equal or higher column values than the one being inserted. 
                        // Add the cell to be inserted into the temp list and re-index all of the cells.
                        List<Cell> cells = row.Descendants<Cell>().Where(c => String.Compare(c.CellReference.Value, insertReference) >= 0).ToList();
                        cells.Insert(0, insertCell);
                        string cellReference = insertReference;
    
                        foreach (Cell cell in cells)
                        {
                            // Update the references for the rows cells.
                            cell.CellReference = new StringValue(cellReference);
                            IncrementCellReference(cellReference, CellReferencePartEnum.Column);
                        }
    
                        // actually insert the new cell into the row
                        retCell = row.InsertBefore(insertCell, retCell);  // at this point, retCell still points to the row that had the insertReference
                    }
                }
                // Else retCell is null, this means no cell exists at the specified location so we need to put a new cell in that space.  
                // If a cell was passed into this method, then it will be inserted. If not, a new one will be inserted.
                else
                {
                    // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                    // Sequencial order can't be string comparison order, has to be Excel order ("A", "B", ... "AA", "BB", etc)
                    Cell refCell = null;
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        string cellColumn = Regex.Replace(cell.CellReference.Value, @"\d", "");
                        if (colName.Length <= cellColumn.Length && string.Compare(cell.CellReference.Value, insertReference, true) > 0)
                        {
                            refCell = cell;
                            break;
                        }
                    }
    
                    // Insert cell parameter is supplied, otherwise, create a new cell
                    retCell = insertCell ?? new Cell() { CellReference = insertReference };
                    row.InsertBefore(retCell, refCell);
                }
    
                return retCell;
            }
