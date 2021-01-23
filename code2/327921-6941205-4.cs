    private static readonly object UnitTableLock = new object();
    private static DataTable unitTable;
    private static bool _ready = false;
    
    public static DataTable GetUnitList()
    {
        if (!_ready)
        {
            lock (UnitTableLock)
            {
                if (!_ready)
                {
                    unitTable = new DataTable; //... etc
                    System.Threading.Thread.MemoryBarrier();
                    _ready = true;
                }
            }
        }
    
        return unitTable;
    }
