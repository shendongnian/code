	public static IWithManagedCreate WithExistingDataDisks(this IWithManagedCreate vm, params IDisk[] disks)
	{
		foreach (var disk in disks)
		{
			vm.WithExistingDataDisk(disk);
		}
		return vm; 
	}
