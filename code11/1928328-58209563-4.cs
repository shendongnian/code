     using System;
     using System.IO;
     using System.Runtime.InteropServices;
     using System.Threading.Tasks;
     using System.Transactions; // must add reference to System.Transactions     
    public class FileHelper
        {
            #region | Public Events |
    
            /// <summary>
            /// Occurs when any progress changes occur with file.
            /// </summary>
            public event ProgressChangeDelegate OnProgressChanged;
    
            /// <summary>
            /// Occurs when file process has been completed.
            /// </summary>
            public event OnCompleteDelegate OnComplete;
    
            #endregion
    
            #region | Enums |
    
            [Flags]
            enum MoveFileFlags : uint
            {
            MOVE_FILE_REPLACE_EXISTSING = 0x00000001,
            MOVE_FILE_COPY_ALLOWED = 0x00000002,
            MOVE_FILE_DELAY_UNTIL_REBOOT = 0x00000004,
            MOVE_FILE_WRITE_THROUGH = 0x00000008,
            MOVE_FILE_CREATE_HARDLINK = 0x00000010,
            MOVE_FILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
            }
    
            enum CopyProgressResult : uint
            {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3,
            }
    
            enum CopyProgressCallbackReason : uint
            {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
            }
    
            #endregion
    
            #region | Delegates |
    
            private delegate CopyProgressResult CopyProgressRoutine(
            long TotalFileSize,
            long TotalBytesTransferred,
            long StreamSize,
            long StreamBytesTransferred,
            uint dwStreamNumber,
            CopyProgressCallbackReason dwCallbackReason,
            IntPtr hSourceFile,
            IntPtr hDestinationFile,
            IntPtr lpData);
    
            public delegate void ProgressChangeDelegate(double percentage);
    
            public delegate void OnCompleteDelegate(bool completed);
    
            #endregion
    
            #region | Imports |
    
            [DllImport("Kernel32.dll")]
            private static extern bool CloseHandle(IntPtr handle);
    
            [DllImport("Kernel32.dll")]
            private static extern bool MoveFileTransactedW([MarshalAs(UnmanagedType.LPWStr)]string existingfile, [MarshalAs(UnmanagedType.LPWStr)]string newfile,
                IntPtr progress, IntPtr lpData, IntPtr flags, IntPtr transaction);
    
            [DllImport("Kernel32.dll")]
            private static extern bool MoveFileWithProgressA(string existingfile, string newfile,
                CopyProgressRoutine progressRoutine, IntPtr lpData, MoveFileFlags flags);
    
            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("79427A2B-F895-40e0-BE79-B57DC82ED231")]
            private interface IKernelTransaction
            {
                void GetHandle([Out] out IntPtr handle);
            }
    
            #endregion
    
            #region | Public Routines |
    
            /// <summary>
            /// Will attempt to move a file using a transaction, if successful then the source file will be deleted.
            /// </summary>
            /// <param name="existingFile"></param>
            /// <param name="newFile"></param>
            /// <returns></returns>
            public static bool MoveFileTransacted(string existingFile, string newFile)
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
                            tx.Complete();
                        }
                        CloseHandle(txh);
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
    
            /// <summary>
            /// Attempts to move a file from one destination to another. If it succeeds, then the source
            /// file is deleted after successful move.
            /// </summary>
            /// <param name="fileToMove"></param>
            /// <param name="newFilePath"></param>
            /// <returns></returns>
            public async Task<bool> MoveFileAsyncWithProgress(string fileToMove, string newFilePath)
            {
                bool success = false;
    
                try
                {
                    await Task.Run(() =>
                    {
                        success = MoveFileWithProgressA(fileToMove, newFilePath, new CopyProgressRoutine(CopyProgressHandler), IntPtr.Zero, MoveFileFlags .MOVE_FILE_REPLACE_EXISTSING|MoveFileFlags.MOVE_FILE_WRITE_THROUGH|MoveFileFlags.MOVE_FILE_COPY_ALLOWED);
                    });
                }
                catch (Exception ex)
                {
                    success = false;
                }
                finally
                {
                    OnComplete(success);
                }
    
                return success;
            }
    
            private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize, long StreamByteTrans, uint dwStreamNumber,CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
            {
                double percentage = transferred * 100.0 / total;
                OnProgressChanged(percentage);
    
                return CopyProgressResult.PROGRESS_CONTINUE;
            }
    
            #endregion
        }
