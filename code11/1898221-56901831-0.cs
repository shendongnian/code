    var output = string.Format("VM ID is \"{0}\". State is: \"{1}\". Location: \"{2}\" and the Instance Type is \"{3}\". Key is \"{4}\".",
                 vm.InstanceId, vm.State, vm.Region, vm.InstanceType, vm.KeyName);
    if (vm.Name != null) {
        output.Replace("VM ", $"VM name is "\"{vm.Name}\" ")
    }
