    public IEnumerable<CellData> Cells(int index) 
    {
        var foundRow = rowList.FirstOrDefault(row => row.ID == index);
        if(foundRow != null)
            return foundRow.AsEnumerable<CellData>();
        else
            return null;
        }
    }
