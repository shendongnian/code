    using System;
    using System.Runtime.InteropServices;
    
    
    namespace MyCompany.MyTechnology.Framework.CrossDomain.GuidExtend
    {
        public static class Guid
        {
    
            /*
    
            Original Reference for Code:
            http://www.pinvoke.net/default.aspx/rpcrt4/UuidCreateSequential.html
    
            */
    
    
            [DllImport("rpcrt4.dll", SetLastError = true)]
            static extern int UuidCreateSequential(out System.Guid guid);
    
            public static System.Guid NewGuid()
            {
                return CreateSequentialUuid();
            }
    
    
            public static System.Guid CreateSequentialUuid()
            {
                const int RPC_S_OK = 0;
                System.Guid g;
                int hr = UuidCreateSequential(out g);
                if (hr != RPC_S_OK)
                    throw new ApplicationException("UuidCreateSequential failed: " + hr);
                return g;
            }
    
    
            /*
    
            Text From URL above:
    
            UuidCreateSequential (rpcrt4)
     
            Type a page name and press Enter. You'll jump to the page if it exists, or you can create it if it doesn't.
            To create a page in a module other than rpcrt4, prefix the name with the module name and a period.
            . Summary
            Creates a new UUID 
            C# Signature:
            [DllImport("rpcrt4.dll", SetLastError=true)]
            static extern int UuidCreateSequential(out Guid guid);
    
    
            VB Signature:
            Declare Function UuidCreateSequential Lib "rpcrt4.dll" (ByRef id As Guid) As Integer
    
    
            User-Defined Types:
            None.
    
            Notes:
            Microsoft changed the UuidCreate function so it no longer uses the machine's MAC address as part of the UUID. Since CoCreateGuid calls UuidCreate to get its GUID, its output also changed. If you still like the GUIDs to be generated in sequential order (helpful for keeping a related group of GUIDs together in the system registry), you can use the UuidCreateSequential function.
    
            CoCreateGuid generates random-looking GUIDs like these:
    
            92E60A8A-2A99-4F53-9A71-AC69BD7E4D75
            BB88FD63-DAC2-4B15-8ADF-1D502E64B92F
            28F8800C-C804-4F0F-B6F1-24BFC4D4EE80
            EBD133A6-6CF3-4ADA-B723-A8177B70D268
            B10A35C0-F012-4EC1-9D24-3CC91D2B7122
    
    
    
            UuidCreateSequential generates sequential GUIDs like these:
    
            19F287B4-8830-11D9-8BFC-000CF1ADC5B7
            19F287B5-8830-11D9-8BFC-000CF1ADC5B7
            19F287B6-8830-11D9-8BFC-000CF1ADC5B7
            19F287B7-8830-11D9-8BFC-000CF1ADC5B7
            19F287B8-8830-11D9-8BFC-000CF1ADC5B7
    
    
    
            Here is a summary of the differences in the output of UuidCreateSequential:
    
            The last six bytes reveal your MAC address 
            Several GUIDs generated in a row are sequential 
            Tips & Tricks:
            Please add some!
    
            Sample Code in C#:
            static Guid UuidCreateSequential()
            {
               const int RPC_S_OK = 0;
               Guid g;
               int hr = UuidCreateSequential(out g);
               if (hr != RPC_S_OK)
                 throw new ApplicationException
                   ("UuidCreateSequential failed: " + hr);
               return g;
            }
    
    
    
            Sample Code in VB:
            Sub Main()
               Dim myId As Guid
               Dim code As Integer
               code = UuidCreateSequential(myId)
               If code <> 0 Then
                 Console.WriteLine("UuidCreateSequential failed: {0}", code)
               Else
                 Console.WriteLine(myId)
               End If
            End Sub
    
    
    
    
            */
    
    
    
    
    
    
    
    
        }
    }
