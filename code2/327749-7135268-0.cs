    public struct MEMORYSTATUS
    {
        public UInt32 dwLength;
        public UInt32 dwMemoryLoad;
        public UInt32 dwTotalPhys;
        public UInt32 dwAvailPhys;
        public UInt32 dwTotalPageFile;
        public UInt32 dwAvailPageFile;
        public UInt32 dwTotalVirtual;
        public UInt32 dwAvailVirtual;
    }
    [DllImport("coredll.dll")]
    private static extern int GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);
    public static void GetGlobalMemoryStatus(ref UInt32 dwTotal, ref UInt32 dwAvail,
                                                 ref UInt32 dwProcTotal, ref UInt32 dwProcAvail)
    {
        MEMORYSTATUS status = new MEMORYSTATUS();
        GlobalMemoryStatus(ref status);
        dwTotal = status.dwTotalPhys;
        dwAvail = status.dwAvailPhys;
        dwProcTotal = status.dwTotalVirtual;
        dwProcAvail = status.dwAvailVirtual;
    }
    private void UpdateMemoryDisplay()
    {
        /*************************************************************************/
        bool IsTotalGB = false;
        bool IsUsedGB = false;
        uint TotalRamMemory = 0;
        uint AvailRamMemory = 0;
        uint ProcTotalRamMemory = 0;
        uint ProcAvailRamMemory = 0;
        
        GetGlobalMemoryStatus(ref TotalRamMemory, ref AvailRamMemory,
                              ref ProcTotalRamMemory, ref ProcAvailRamMemory);
        float TotalMB = (float)((float)TotalRamMemory / (1024 * 1024));
        float UsedMB = TotalMB - (float)((float)AvailRamMemory / (1024 * 1024));
        int RamPercent = (int)((UsedMB / TotalMB) * 100.0);
        if (1000 < TotalMB)
        {
            TotalMB /= 1000;
            IsTotalGB = true;
        }
        if (1000 < UsedMB)
        {
            UsedMB /= 1000;
            IsUsedGB = true;
        }
        this.RamMemMinLbl.Text = UsedMB.ToString("0.0") + ((false != IsUsedGB) ? "GB" : "MB");
        this.RamMemMaxLbl.Text = TotalMB.ToString("0.0") + ((false != IsTotalGB) ? "GB" : "MB");
        this.RamMemPercent.Current = RamPercent;
        IsUsedGB = false;
        TotalMB = (float)((float)ProcTotalRamMemory / (1024 * 1024));
        UsedMB = TotalMB - (float)((float)ProcAvailRamMemory / (1024 * 1024));
        if (1000 < UsedMB)
        {
            UsedMB /= 1000;
            IsUsedGB = true;
        }
        this.ProcRamMemMinLbl.Text = UsedMB.ToString("0.0") + ((false != IsUsedGB) ? "GB" : "MB");
        IsUsedGB = false;
        UsedMB = (float)((float)GC.GetTotalMemory(false) / (1024 * 1024));
        if (1000 < UsedMB)
        {
            UsedMB /= 1000;
            IsUsedGB = true;
        }
        this.GCMemMinLbl.Text = UsedMB.ToString("0.0") + ((false != IsUsedGB) ? "GB" : "MB");
        /*************************************************************************/
    }
