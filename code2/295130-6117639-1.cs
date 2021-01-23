    internal partial class MyScanner : IScanner
    {
        internal void SetHardware(Hardware hardware)
        {
            ...
        }
    }
    internal partial class MyScanner
    {
        void IScanner.SetHardware(Hardware hardware)
        {
            this.SetHardware(hardware);
        }
    }
