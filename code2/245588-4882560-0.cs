    [ComVisible(true)]
    [Guid("28888fe3-c2a0-483a-a3ea-8cb1ce51ff3d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITextStoreACP 
    {
        uint AdviseSink(
            ref Guid Iid, 
            [MarshalAs(UnmanagedType.IUnknown)] object pUnknown, 
            uint Mask
            );
        .......
    }
    
    
    
    public class TextStore : ITextStoreACP
    {
        #region ITextStoreACP Members
    
        public uint AdviseSink(ref Guid Iid, object pUnknown, uint Mask)
        {
            throw new NotImplementedException();
        }
        .....
    }
