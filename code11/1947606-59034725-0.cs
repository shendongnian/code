    [HttpGet]
    public IActionResult GetVMs()
    {
        var model =
            from vm in _context.VirtualMachines
            join project in _context.Projects on vm.ProjectId equals project.Id
            join hypervisor in _context.Hypervisors on vm.HypervisorId equals 
            hypervisor.HypervisorId
            join managment in _context.Managements on vm.ManagementId equals managment.Id
            select new
            {
                Name = vm.Name,
                IpAddress = vm.IpAddress,
                DiskSize = vm.DiskSize,
                Cpu = vm.CPU,
                Ram = vm.Ram,
                ImageUrl = vm.ImageUrl,
                Role = vm.Role.ToString(),
                Status = vm.Status.ToString(),
                Project = project.Name,
                Hypervisor = hypervisor.Name,
                Gateway = managment.Gateway,
                Netmask = managment.Netmask
            };
        return Ok(model);
    }
