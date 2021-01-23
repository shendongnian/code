    // [System.Diagnostics.DebuggerNonUserCode()]  works too
    [System.Diagnostics.DebuggerHidden()]
    private static Excel.Range TrySpecialCells(Excel.Worksheet sheet, Excel.XlCellType cellType)
    {
        try
        {
            return sheet.Cells.SpecialCells(cellType);
        }
        catch (TargetInvocationException)
        {
            return null;
        }
        catch (COMException)
        {
            return null;
        }
    }
