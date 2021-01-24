`
class Program
{
    static void Main(string[] args)
    {
        GacUtility.CreateAssemblyCache(out IntPtr x, 0);
    }
}
public class GacUtility
{
    [DllImport(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\fusion.dll")]
    public static extern int CreateAssemblyCache(out IntPtr asmCache, int reserved);
}
`
yet, for x86 it strangely did not
