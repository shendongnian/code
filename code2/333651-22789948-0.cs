        private Cell CreateCellWithValue(DateTime columnValue, uint? styleIndex, string cellReference)
        {
            Cell c = new Cell();
            c.DataType = CellValues.Number;
            c.CellValue = new CellValue(columnValue.ToOADate().ToString(new CultureInfo("en-US")));
            c.CellReference = cellReference;
            c.StyleIndex = styleIndex;
            return c;
        }
