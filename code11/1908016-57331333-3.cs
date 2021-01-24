    public class SyncLogViewModel
    {
        private readonly SyncLog _syncLog;
        public SyncLogViewModel(SyncLog syncLog) =>
             _syncLog = syncLog ?? throw new ArgumentNullException(nameof(syncLog));
        public int sl_StructLength => _syncLog.sl_Struct?.Length ?? 0;
        public int sl_Struct 
        {
             get => _syncLog.sl_Struct;
             set => _syncLog.sl_Struct = value;
        }
        // Other properties...
    }
