    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using Microsoft.Win32;
    ...
    class Program
    {
        private const int S_OK = 0x00000000;
        
        [DllImport("ole32.dll")]
    	private static extern int GetRunningObjectTable(uint reserved, out IRunningObjectTable pprot);
    	
     	[DllImport("ole32.dll")]
    	private static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);   	
    	
    	private static void OleCheck(string message, int result)
    	{
            if (result != S_OK)
                throw new COMException(message, result);
    	}
    	
    	private static System.Collections.Generic.IEnumerable<IMoniker> EnumRunningObjects()
    	{    		
            IRunningObjectTable objTbl;
            OleCheck("GetRunningObjectTable failed", GetRunningObjectTable(0, out objTbl));
            IEnumMoniker enumMoniker;
            IMoniker[] monikers = new IMoniker[1];
            objTbl.EnumRunning(out enumMoniker);
            enumMoniker.Reset();
            while (enumMoniker.Next(1, monikers, IntPtr.Zero) == S_OK)
            {
                yield return monikers[0];
            }
    	}
		
    	private static bool TryGetCLSIDFromDisplayName(string displayName, out string clsid)
    	{
            var bBracket = displayName.IndexOf("{");
            var eBracket = displayName.IndexOf("}");
            if ((bBracket > 0) && (eBracket > 0) && (eBracket > bBracket))
            {
                clsid = displayName.Substring(bBracket, eBracket - bBracket + 1);
                return true;
            }
            else 
            {
                clsid = string.Empty;
                return false;
            }	
    	}
    	
    	private static string ReadSubKeyValue(string keyName, RegistryKey key)
    	{
            var subKey = key.OpenSubKey(keyName);
            if (subKey != null)
            {
                using(subKey)
                {
                    var value = subKey.GetValue("");
                    return value == null ? string.Empty : value.ToString();
                }
            }
            return string.Empty;
    	}
    	
    	private static string GetMonikerString(IMoniker moniker)
    	{
            IBindCtx ctx;
            OleCheck("CreateBindCtx failed", CreateBindCtx(0, out ctx));
            var sb = new StringBuilder();
            string displayName;
            moniker.GetDisplayName(ctx, null, out displayName);
            sb.Append(displayName);
            sb.Append('\t');
            string clsid; 
            if (TryGetCLSIDFromDisplayName(displayName, out clsid))
            {
                var regClass = Registry.ClassesRoot.OpenSubKey("\\CLSID\\" + clsid);
                if (regClass != null)
                {
                    using(regClass)
                    {
                        sb.Append(regClass.GetValue(""));
                        sb.Append('\t');
                        sb.Append(ReadSubKeyValue("ProgID", regClass));
                        sb.Append('\t');
                        sb.Append(ReadSubKeyValue("LocalServer32", regClass));
                    }
                }
            }
            return sb.ToString();
    	}
    	
    	[STAThread]
    	public static void Main(string[] args)
    	{
            Console.WriteLine("DisplayName\tRegId\tProgId\tServer");
            foreach(var moniker in EnumRunningObjects())
            {
                Console.WriteLine(GetMonikerString(moniker));
            }
    	}
    }  
