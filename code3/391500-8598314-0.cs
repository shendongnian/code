        // traditional.
        Hosts = new List<HostMachineToUpdate>();
        foreach (char x in "abcd")
        {
            List<VirtualMachineToUpdate> Guests = new List<VirtualMachineToUpdate>();
            int randomItemNum = new Random().Next(3, 8);
            for (int y = 1; y < randomItemNum; y++)
            {
                Guests.Add(new VirtualMachineToUpdate(x + y.ToString() + "_VM"));
            }
            Hosts.Add(new HostMachineToUpdate(x + "Host", Guests));
        }
