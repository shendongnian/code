    public static class NVMeQuery
    {
    	[DllImport("NVMeQuery.dll", CallingConvention = CallingConvention.StdCall)]
    	internal static extern IntPtr New(InteropBase.AssetCallback callback);
    	[DllImport("NVMeQuery.dll", CallingConvention = CallingConvention.Cdecl)]
    	internal static extern ulong GetTemp(IntPtr p, IntPtr drivePath);
    }
    
    public class NVMeQueries : InteropBase
    {
    	public NVMeQueries()
    	{
    		_ptr = NVMeQuery.New(_onAssetErrorMessageChanged);
    	}
    
    	public ulong GetTemp() => GetTemp(@"\\.\PhysicalDrive4");
    
    	public ulong GetTemp(string drivePath)
    	{
    		var strPtr = Marshal.StringToHGlobalAuto(drivePath);
    		var result = NVMeQuery.GetTemp(_ptr, strPtr);
    		Marshal.FreeHGlobal(strPtr);
    		return result;
    	}
    }
