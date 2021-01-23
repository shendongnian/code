    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    
    namespace PETest2
    {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct IMAGE_IMPORT_BY_NAME
        {
            [FieldOffset(0)]
            public ushort Hint;
            [FieldOffset(2)]
            public fixed char Name[1];
        }
    
        [StructLayout(LayoutKind.Explicit)]
        public struct IMAGE_IMPORT_DESCRIPTOR
        {
            #region union
            /// <summary>
            /// CSharp doesnt really support unions, but they can be emulated by a field offset 0
            /// </summary>
    
            [FieldOffset(0)]
            public uint Characteristics;            // 0 for terminating null import descriptor
            [FieldOffset(0)]
            public uint OriginalFirstThunk;         // RVA to original unbound IAT (PIMAGE_THUNK_DATA)
            #endregion
    
            [FieldOffset(4)]
            public uint TimeDateStamp;
            [FieldOffset(8)]
            public uint ForwarderChain;
            [FieldOffset(12)]
            public uint Name;
            [FieldOffset(16)]
            public uint FirstThunk;
        }
    
        [StructLayout(LayoutKind.Explicit)]
        public struct THUNK_DATA
        {
            [FieldOffset(0)]
            public uint ForwarderString;      // PBYTE 
            [FieldOffset(0)]
            public uint Function;             // PDWORD
            [FieldOffset(0)]
            public uint Ordinal;
            [FieldOffset(0)]
            public uint AddressOfData;        // PIMAGE_IMPORT_BY_NAME
        }
    
        public unsafe class Interop
        {
            #region Public Constants
            public static readonly ushort IMAGE_DIRECTORY_ENTRY_IMPORT = 1;
            #endregion
            #region Private Constants
            #region CallingConvention CALLING_CONVENTION
            /// <summary>
            ///     Specifies the calling convention.
            /// </summary>
            /// <remarks>
            ///     Specifies <see cref="CallingConvention.Winapi" /> for Windows to 
            ///     indicate that the default should be used.
            /// </remarks>
            private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
            #endregion CallingConvention CALLING_CONVENTION
            #region IMPORT DLL FUNCTIONS
            private const string KERNEL_DLL = "kernel32";
            private const string DBGHELP_DLL = "Dbghelp";
            #endregion
            #endregion Private Constants
    
            [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "GetModuleHandleA"), SuppressUnmanagedCodeSecurity]
            public static extern void* GetModuleHandleA(/*IN*/ char* lpModuleName);
    
            [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "GetModuleHandleW"), SuppressUnmanagedCodeSecurity]
            public static extern void* GetModuleHandleW(/*IN*/ char* lpModuleName);
    
            [DllImport(KERNEL_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "IsBadReadPtr"), SuppressUnmanagedCodeSecurity]
            public static extern bool IsBadReadPtr(void* lpBase, uint ucb);
    
            [DllImport(DBGHELP_DLL, CallingConvention = CALLING_CONVENTION, EntryPoint = "ImageDirectoryEntryToData"), SuppressUnmanagedCodeSecurity]
            public static extern void* ImageDirectoryEntryToData(void* Base, bool MappedAsImage, ushort DirectoryEntry, out uint Size);
    
    
        }
    
    
        static class Foo
        {
            // From winbase.h in the Win32 platform SDK.
            //
            const uint DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
            const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
    
            [DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
            static extern uint LoadLibraryEx(string fileName, uint notUsedMustBeZero, uint flags);
    
            public static void Main()
            {
                //var path = @"c:\windows\system32\mscoree.dll";
                //var path = @"c:\windows\system32\gdi32.dll";
                var path = @"c:\windows\system32\wsock32.dll";
                var hLib = LoadLibraryEx(path, 0,
                                         DONT_RESOLVE_DLL_REFERENCES | LOAD_IGNORE_CODE_AUTHZ_LEVEL);
                TestImports(hLib, true);
    
            }
    
    
            // using mscoree.dll as an example as it doesnt export any thing
            // so nothing shows up if you use your own module.
            // and the only none delayload in mscoree.dll is the Kernel32.dll
            private static void TestImports(uint hLib, bool mappedAsImage)
            {
                unsafe
                {
                    //fixed (char* pszModule = "mscoree.dll")
                    {
                        //void* hMod = Interop.GetModuleHandleW(pszModule);
                        void* hMod = (void*)hLib;
    
                        uint size = 0;
                        uint BaseAddress = (uint)hMod;
    
                        if (hMod != null)
                        {
                            Console.WriteLine("Got handle");
    
                            IMAGE_IMPORT_DESCRIPTOR* pIID = (IMAGE_IMPORT_DESCRIPTOR*)Interop.ImageDirectoryEntryToData((void*)hMod, mappedAsImage, Interop.IMAGE_DIRECTORY_ENTRY_IMPORT, out size);
                            if (pIID != null)
                            {
                                Console.WriteLine("Got Image Import Descriptor");
                                while (pIID->OriginalFirstThunk != 0)
                                {
                                    try
                                    {
                                        char* szName = (char*)(BaseAddress + pIID->Name);
                                        string name = Marshal.PtrToStringAnsi((IntPtr)szName);
                                        Console.WriteLine("pIID->Name = {0} BaseAddress - {1}", name, (uint)BaseAddress);
    
                                        THUNK_DATA* pThunkOrg = (THUNK_DATA*)(BaseAddress + pIID->OriginalFirstThunk);
    
                                        while (pThunkOrg->AddressOfData != 0)
                                        {
                                            char* szImportName;
                                            uint Ord;
    
                                            if ((pThunkOrg->Ordinal & 0x80000000) > 0)
                                            {
                                                Ord = pThunkOrg->Ordinal & 0xffff;
                                                Console.WriteLine("imports ({0}).Ordinal{1} - Address: {2}", name, Ord, pThunkOrg->Function);
                                            }
                                            else
                                            {
                                                IMAGE_IMPORT_BY_NAME* pIBN = (IMAGE_IMPORT_BY_NAME*)(BaseAddress + pThunkOrg->AddressOfData);
    
                                                if (!Interop.IsBadReadPtr((void*)pIBN, (uint)sizeof(IMAGE_IMPORT_BY_NAME)))
                                                {
                                                    Ord = pIBN->Hint;
                                                    szImportName = (char*)pIBN->Name;
                                                    string sImportName = Marshal.PtrToStringAnsi((IntPtr)szImportName); // yes i know i am a lazy ass
                                                    Console.WriteLine("imports ({0}).{1}@{2} - Address: {3}", name, sImportName, Ord, pThunkOrg->Function);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Bad ReadPtr Detected or EOF on Imports");
                                                    break;
                                                }
                                            }
    
                                            pThunkOrg++;
                                        }
                                    }
                                    catch (AccessViolationException e)
                                    {
                                        Console.WriteLine("An Access violation occured\n" +
                                                          "this seems to suggest the end of the imports section\n");
                                        Console.WriteLine(e);
                                    }
    
                                    pIID++;
                                }
    
                            }
    
                        }
                    }
                }
    
                Console.WriteLine("Press Any Key To Continue......");
                Console.ReadKey();
            }
        }
    }
