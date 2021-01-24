sql
declare @hid hierarchyid = '/1/1/1/';
    
select 
    v1 = convert(varchar(1000), cast(@hid as varbinary(892)), 1), -- = 0x5AD6
    v2 = convert(varchar(1000), cast(@hid as varbinary(892)), 2); -- = 5AD6
In C#:
cs
using System;
using Microsoft.SqlServer.Types;
using System.IO;
    					
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Conversion of SqlHierarchyId to Hex string:");
    		
        var hid = SqlHierarchyId.Parse("/1/-1.12/-2.2.39/");	
    		
    	Console.WriteLine(HierarchyIdToHexString(hid));	// = 0x5A2C9F9D93E0	
    }
    	
    private static String HierarchyIdToHexString(SqlHierarchyId hid) 
    {
    	using (var ms = new MemoryStream())
    	using (var binWriter = new BinaryWriter(ms))
        {
    	    hid.Write(binWriter);	
            var byteString = BitConverter.ToString(ms.ToArray()).Replace("-","");
            return String.Format("0x{0}", byteString);			
        }
    }	
}
Here is the working example on [dotnetfiddle.net][1]
@Uranne, use HierarchyIdToHexString() method in your ToCsv().  
  [1]: https://dotnetfiddle.net/Lp9WcX
