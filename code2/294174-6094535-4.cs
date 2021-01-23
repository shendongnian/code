    ==ex.StackTrace==
       at stack.Program.Third() in C:\Temp\customers\stack\Program.cs:line 35
    
    ==Environment.StackTrace per Guillaume==
       at stack.Program.Third() in C:\Temp\customers\stack\Program.cs:line 35   at S
    ystem.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
       at System.Environment.get_StackTrace()
       at stack.Program.Third() in C:\Temp\customers\stack\Program.cs:line 44
       at stack.Program.Main(String[] args) in C:\Temp\customers\stack\Program.cs:li
    ne 15
       at System.AppDomain._nExecuteAssembly(Assembly assembly, String[] args)
       at System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySec
    urity, String[] args)
       at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
       at System.Threading.ThreadHelper.ThreadStart_Context(Object state)
       at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, C
    ontextCallback callback, Object state)
       at System.Threading.ThreadHelper.ThreadStart()
    
    ==ex.ToString() per danyolgiax==
    System.SystemException: ERROR HERE!
       at stack.Program.Third() in C:\Temp\customers\stack\Program.cs:line 35
    
    ==GetFrame(i) per MBen/Jorge Córdoba==
    Void Third(): (line 52)
    Void Main(System.String[]): (line 15)
    Int32 _nExecuteAssembly(System.Reflection.Assembly, System.String[]): (line 0)
    Int32 ExecuteAssembly(System.String, System.Security.Policy.Evidence, System.Str
    ing[]): (line 0)
    Void RunUsersAssembly(): (line 0)
    Void ThreadStart_Context(System.Object): (line 0)
    Void Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, Sy
    stem.Object): (line 0)
    Void ThreadStart(): (line 0)
