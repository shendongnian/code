    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
    [ComVisible(true)]
    public interface IComClassApiCaller
    {
        IComClassDellAsset GetDellAsset(string serviceTag, string apiKey);
    }
    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA71"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface IComClassApiCallerEvents
    {
    }
    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(IComClassApiCallerEvents))]
    [ComVisible(true)]
    [ProgId("ProgId.ApiCaller")]
    public class ApiCaller : IComClassApiCaller {
       
        public IComClassDellAsset GetDellAsset(string serviceTag, string apiKey)
        {
            .....
        }
    }
 
    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83E")]
    [ComVisible(true)]
    public interface IComClassDellAsset
    {
         string CountryLookupCode { get; set; }
         string CustomerNumber { get; set; }
         bool IsDuplicate { get; set; }
         string ItemClassCode { get; set; }
         string LocalChannel { get; set; }
         string MachineDescription { get; set; }
         string OrderNumber { get; set; }
         string ParentServiceTag { get; set; }
         string ServiceTag { get; set; }
         string ShipDate { get; set; }
    }
    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA70"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComVisible(true)]
    public interface IComClassDellAssetEvents
    {
    }
    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F937"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(IComClassDellAssetEvents))]
    [ComVisible(true)]
    [ProgId("ProgId.DellAsset")]
    public class DellAsset : IComClassDellAsset
    {
        public string CountryLookupCode { get; set; }
        public string CustomerNumber { get; set; }
        public bool IsDuplicate { get; set; }
        public string ItemClassCode { get; set; }
        public string LocalChannel { get; set; }
        public string MachineDescription { get; set; }
        public string OrderNumber { get; set; }
        public string ParentServiceTag { get; set; }
        public string ServiceTag { get; set; }
        public string ShipDate { get; set; }
    }
