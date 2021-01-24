    public static class WithManagedDataDiskExtensions
    {
        public static IWithManagedDataDisk WithExistingDataDisks(this IWithManagedDataDisk self, params IDisk[] disks)
        {
            foreach (var disk in disks)
                self.WithExistingDataDisk(disk);
            return self;
        }
    }
