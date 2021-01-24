    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Transactions;
    
    namespace MoveFileRollback
    {
        public abstract class FileTransactionHelper
        {
            [DllImport("Kernel32.dll")]
            private static extern bool CloseHandle(IntPtr handle);
    
            [DllImport("Kernel32.dll")]
            private static extern bool MoveFileTransactedW([MarshalAs(UnmanagedType.LPWStr)]string existingfile, [MarshalAs(UnmanagedType.LPWStr)]string newfile,
                IntPtr progress, IntPtr lpData, IntPtr flags, IntPtr transaction);
    
            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("79427A2B-F895-40e0-BE79-B57DC82ED231")]
            private interface IKernelTransaction
            {
                void GetHandle([Out] out IntPtr handle);
            }
    
            public static bool MoveFile(string existingFile, string newFile)
            {
                bool success = true;
                using (TransactionScope tx = new TransactionScope())
                {
                    if (Transaction.Current != null)
                    {
                        IKernelTransaction kt = (IKernelTransaction)TransactionInterop.GetDtcTransaction(Transaction.Current);
                        IntPtr txh;
                        kt.GetHandle(out txh);
    
                        if (txh == IntPtr.Zero) { success = false; return success; }
    
                        success = MoveFileTransactedW(existingFile, newFile, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, txh);
    
                        if (success)
                        {
                            CloseHandle(txh);
                            tx.Complete();
                        }
                        else { CloseHandle(txh); }
                    }
                    else
                    {
                        try
                        {
                            File.Move(existingFile, newFile);
                            return success;
                        }
                        catch (Exception ex) { success = false; }
                    }
    
                    return success;
                }
            }
        }
    }
