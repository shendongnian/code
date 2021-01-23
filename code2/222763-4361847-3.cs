    IList<IMachine> machines = ...
    
    foreach (IMachine machine in machines)
    {
        MachineLine machineLine = machine as MachineLine;
        if (machineLine != null)
            ProcessLine(machineLine);
 
        else
        {
            MachineCircle machineCircle = machine as MachineCircle;
            if (machineCircle != null)
                ProcessCircle(machineCircle);
            else throw new UnknownMachineException(...);
        }
    }
