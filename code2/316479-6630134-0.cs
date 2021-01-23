    public IEnumerable<CellData> Cells(int index) 
    {
        var foundRow = rowList.Where(row => row.ID == index).FirstOrDefault();
        if(foundRow != null)
            return row.AsEnumerable<CellData>();
        else
            return null;
        }
    }
