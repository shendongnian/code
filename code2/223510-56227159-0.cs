    public delegate void AllocationService_RaiseAllocLog(string orderNumber, string message, bool logToDatabase);
    public delegate void AllocationService_RaiseAllocErrorLog(string orderNumber, string message, bool logToDatabase);
    public class AllocationService { ...
        public event AllocationService_RaiseAllocLog RaiseAllocLog;
        public event AllocationService_RaiseAllocErrorLog RaiseAllocErrorLog;
