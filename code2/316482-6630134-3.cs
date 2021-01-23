    public IEnumerable<CellData> Cells(int index) 
    {
        var foundRow = rowList.FirstOrDefault(row => row.ID == index);
        //if no row was found, foundRow will be null
        if(foundRow != null)
            return foundRow.AsEnumerable<CellData>();
        else
            return new CellData[]; //return empty cells IEnumerable. Could also be new List<CellData>()
        }
    }
