<Code>[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]                  
public struct FT_SERVER_USB_DEVICE               
{        
    public FT_USB_UNIQID usbHWID;      
    public eFtUsbDeviceStatus status;       
    public bool bExcludeDevice;       
    public bool bSharedManually;          
    public uint ulDeviceId;       
    public uint ulClientAddr;         
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]        
    public string szUsbDeviceDescr;         
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]        
    public string szLocationInfo;         
    public SZNickName szNickName;  
 }</Code>
