    using System;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;
    using System.IO;
    
    namespace GetPeLinkTime {
        class Program {
            static void Main (string[] args) {
                if (args.Length != 1) {
                    Console.WriteLine ("Usage:" + Environment.NewLine + "    GetPeLinkTime ExePathToExamine");
                    return;
                }
                string filePath = args[0];
    
                FileStream file = File.OpenRead (filePath);
                using (var mmf = MemoryMappedFile.CreateFromFile (file, null, 
                                                                  file.Length,
                                                                  MemoryMappedFileAccess.Read,
                                                                  null, HandleInheritability.None, false)) {
                    NativeMethods.IMAGE_DOS_HEADER dosHeader = new NativeMethods.IMAGE_DOS_HEADER ();
                    using (var accessor = mmf.CreateViewAccessor (0,
                                                                  Marshal.SizeOf (dosHeader),
                                                                  MemoryMappedFileAccess.Read)) {
                        accessor.Read<NativeMethods.IMAGE_DOS_HEADER>(0, out dosHeader);
                        if (dosHeader.e_magic != NativeMethods.IMAGE_DOS_SIGNATURE) {
                            Console.WriteLine ("The input file is not an Executable file.");
                            return;
                        }
                    }
                    int signature = 0;
                    NativeMethods.IMAGE_FILE_HEADER imageFileHeader = new NativeMethods.IMAGE_FILE_HEADER();
                    using (var accessor = mmf.CreateViewAccessor (dosHeader.e_lfanew,
                                                                  Marshal.SizeOf (signature) + Marshal.SizeOf (imageFileHeader),
                                                                  MemoryMappedFileAccess.Read)) {
                        signature = accessor.ReadInt32 (0);
                        if (signature != NativeMethods.IMAGE_NT_SIGNATURE) {
                            Console.WriteLine ("The input file is not a Program Executable file.");
                            return;
                        }
                        accessor.Read<NativeMethods.IMAGE_FILE_HEADER> (Marshal.SizeOf (signature), out imageFileHeader);
                    }
                    // convert a Unix timestamp to DateTime
                    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    TimeSpan localOffset = TimeZone.CurrentTimeZone.GetUtcOffset (origin);
                    DateTime originUTC = origin.AddHours(localOffset.Hours);
                    DateTime linkTime = originUTC.AddSeconds ((double)imageFileHeader.TimeDateStamp);
                    Console.WriteLine ("Link time of the file '{0}' is: {1}", filePath, linkTime);
                }
            }
        }
        internal static class NativeMethods {
            internal const int IMAGE_DOS_SIGNATURE = 0x5A4D;    // MZ
            internal const int IMAGE_NT_SIGNATURE = 0x00004550; // PE00
    
            [StructLayout (LayoutKind.Sequential)]
            internal struct IMAGE_DOS_HEADER {  // DOS .EXE header
                internal short e_magic;         // Magic number
                internal short e_cblp;          // Bytes on last page of file
                internal short e_cp;            // Pages in file
                internal short e_crlc;          // Relocations
                internal short e_cparhdr;       // Size of header in paragraphs
                internal short e_minalloc;      // Minimum extra paragraphs needed
                internal short e_maxalloc;      // Maximum extra paragraphs needed
                internal short e_ss;            // Initial (relative) SS value
                internal short e_sp;            // Initial SP value
                internal short e_csum;          // Checksum
                internal short e_ip;            // Initial IP value
                internal short e_cs;            // Initial (relative) CS value
                internal short e_lfarlc;        // File address of relocation table
                internal short e_ovno;          // Overlay number
                internal short e_res1;          // Reserved words
                internal short e_res2;          // Reserved words
                internal short e_res3;          // Reserved words
                internal short e_res4;          // Reserved words
                internal short e_oemid;         // OEM identifier (for e_oeminfo)
                internal short e_oeminfo;       // OEM information; e_oemid specific
                internal short e_res20;         // Reserved words
                internal short e_res21;         // Reserved words
                internal short e_res22;         // Reserved words
                internal short e_res23;         // Reserved words
                internal short e_res24;         // Reserved words
                internal short e_res25;         // Reserved words
                internal short e_res26;         // Reserved words
                internal short e_res27;         // Reserved words
                internal short e_res28;         // Reserved words
                internal short e_res29;         // Reserved words
                internal int e_lfanew;          // File address of new exe header
            }
            [StructLayout (LayoutKind.Sequential)]
            internal struct IMAGE_FILE_HEADER {
                internal short Machine;
                internal short NumberOfSections;
                internal int TimeDateStamp;
                internal int PointerToSymbolTable;
                internal int NumberOfSymbols;
                internal short SizeOfOptionalHeader;
                internal short Characteristics;
            }
            //struct _IMAGE_NT_HEADERS {
            //    DWORD Signature;
            //    IMAGE_FILE_HEADER FileHeader;
            //    IMAGE_OPTIONAL_HEADER32 OptionalHeader;
            //}
            //struct _IMAGE_NT_HEADERS64 {
            //    DWORD Signature;
            //    IMAGE_FILE_HEADER FileHeader;
            //    IMAGE_OPTIONAL_HEADER64 OptionalHeader;
            //}
        }
    }
