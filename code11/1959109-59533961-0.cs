       var expTempVM = azure.VirtualMachines.Define(targetVMName)
            .WithRegion(vm.Region)
            .WithExistingResourceGroup(targetResourceGroupName)
            .WithNewPrimaryNetworkInterface(nicDefinitions[0])
            .WithSpecializedOSDisk(disks[0], disks[0].OSType.Value)
            .WithSize(vm.Size)
            .WithTags(tags);
        
        foreach (var d in disks)
        {
          expTempVM = expTempVM.WithExistingDataDisk(d);
        }
        
        var tempVM = await expTempVM.CreateAsync();
