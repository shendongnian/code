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
    	
    	private static String HierarchyIdToHexString(SqlHierarchyId hid) {
    		using (var ms = new MemoryStream())
    		using (var binWriter = new BinaryWriter(ms))
            {
    			hid.Write(binWriter);	
    			var byteString = BitConverter.ToString(ms.ToArray()).Replace("-","");
    			return String.Format("0x{0}", byteString);			
    		}
    	}	
    }
