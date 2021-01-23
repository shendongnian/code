    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    //[Guid(<Generate GUID here>)]
    public interface _None1
    {
        [DispId(1)]
        int retval { get; }
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    //[Guid(<Generate GUID here>)]
    [ProgId("Lotr.Test")]
    public class None : _None1
    {
        [STAThread]
        public int retval
        {
            get
            { return 1; }
        }
    } 
