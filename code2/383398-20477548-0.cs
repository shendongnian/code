    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    public class RegionHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private RegionHandle() : base(true) {}
        public static readonly RegionHandle Null = new RegionHandle();
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        override protected bool ReleaseHandle()
        {
            return Region.DeleteObject(handle);
        }
    }
