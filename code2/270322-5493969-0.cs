    using VMware.Vim;
    
    //some namespace, some class, some method...
    
    VimClient c = new VimClient();
    ServiceContent sc = c.Connect("hostnameOrIpHere");
    UserSession us = c.Login("usernameHere", "passwordHere");
    
    IList<VMware.Vim.EntityViewBase> vms = c.FindEntityViews(typeof(VMware.Vim.VirtualMachine), null, null, null);
    foreach (VMware.Vim.EntityViewBase tmp in vms)
    {
        VMware.Vim.VirtualMachine vm = (VMware.Vim.VirtualMachine)tmp;
        Console.WriteLine((bool)(vm.Guest.GuestState.Equals("running") ? true : false));
        Console.WriteLine(new Uri(ENDPOINTURL_PREFIX + (vm.Guest.IpAddress != null ? vm.Guest.IpAddress : "0.0.0.0") + ENDPOINTURL_SUFFIX));
        Console.WriteLine((string)vm.Client.ServiceUrl);
        Console.WriteLine(vm.Guest.HostName != null ? (string)vm.Guest.HostName : "");
        Console.WriteLine("----------------");        
    }
