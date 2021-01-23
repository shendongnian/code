    [Flags]
    enum StorageMode
    {
        None = 0,
        Next = 1,
        ...
        Last = 32
    }
    class StorableItem
    {
        public StorageMode StorageMode { get; set; }
    }
