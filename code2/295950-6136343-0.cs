    public class EnableMachine : Device1
    {
        public int Device_Busy; //if 0 busy and 1 not busy 
        public EnableMachine(int dwMachineNumber, int Device_Busy) 
            : base(dwMachineNumber)
        {
            this.Device_Busy = Device_Busy;
        }
    }
