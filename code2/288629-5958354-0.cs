    Imports System.IO
    Imports System.Diagnostics
    Imports System.Runtime.CompilerServices
    Imports System.Runtime.InteropServices
    
    Public Module ExceptionFilter
        Private Enum MINIDUMP_TYPE
            MiniDumpWithFullMemory = 2
        End Enum
    
        <DllImport("dbghelp.dll")>
        Private Function MiniDumpWriteDump(
                ByVal hProcess As IntPtr,
                ByVal ProcessId As Int32,
                ByVal hFile As IntPtr,
                ByVal DumpType As MINIDUMP_TYPE,
                ByVal ExceptionParam As IntPtr,
                ByVal UserStreamParam As IntPtr,
                ByVal CallackParam As IntPtr) As Boolean
        End Function
    
        Function FailFastFilter() As Boolean
            Dim proc = Process.GetCurrentProcess()
            Using stream As FileStream = File.Create("C:\temp\test.dmp")
                MiniDumpWriteDump(proc.Handle, proc.Id, stream.SafeFileHandle.DangerousGetHandle(),
                                  MINIDUMP_TYPE.MiniDumpWithFullMemory, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero)
            End Using
            proc.Kill()
            Return False
        End Function
    
        <Extension()>
        Public Function CrashFilter(ByVal task As Action) As Action
            Return Sub()
                       Try
                           task()
                       Catch ex As Exception When _
                           FailFastFilter()
                       End Try
                   End Sub
        End Function
    End Module
