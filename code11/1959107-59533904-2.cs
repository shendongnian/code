    public static class WithManagedDataDiskExtensions
    {
        // allow to manually specify many disks to add
        public static IWithManagedDataDisk WithExistingDataDisks(this IWithManagedDataDisk self, params IDisk[] disks)
        {
            return self.WithExistingDataDisks((IEnumerable<IDisk>) disks);
        }
        // allow to add an enumerable of many disks
        public static IWithManagedDataDisk WithExistingDataDisks(this IWithManagedDataDisk self, IEnumerable<IDisk> disks)
        {
            foreach (var disk in disks)
                self = self.WithExistingDataDisk(disk);
            return self;
        }
    }
