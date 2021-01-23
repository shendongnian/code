    private static readonly object UnitTableLock = new object();
    private static DataTable unitTable;
    
    public static DataTable GetUnitList()
    {
        if (unitTable == null)
        {
            lock (UnitTableLock)
            {
                if (unitTable == null)
                {
                    unitTable = new DataTable; //... etc
                }
            }
        }
    
        return unitTable;
    }
