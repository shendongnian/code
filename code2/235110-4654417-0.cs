    public class Test {
    
     [DllImport("advapi32.dll", SetLastError = true)]
     static extern bool LogonUser(string principal, string authority, string password, LogonSessionType logonType, LogonProvider logonProvider, out IntPtr token);
    
     [DllImport("kernel32.dll", SetLastError = true)]
     static extern bool CloseHandle(IntPtr handle);
    
     enum LogonSessionType : uint {
      Interactive = 2,
      Network,
      Batch,
      Service,
      NetworkCleartext = 8,
      NewCredentials
     }
    
     enum LogonProvider : uint {
      Default = 0,
      WinNT35,
      WinNT40, //NTLM
      WinNT50  //Kerb or NTLM
     }
     
     void DoTest() {
      IntPtr token = IntPtr.Zero;
      WindowsImpersonationContext user = null;
      try {  
       bool loggedin = LogonUser("username", "authority", "password", LogonSessionType.Interactive, LogonProvider.Default, out token);
       if (loggedin) {
        WindowsIdentity id = new WindowsIdentity(token);
        user = id.Impersonate();
        
        Process [] ipByName = Process.GetProcessesByName("notepad", "169.0.0.0");
       }
      } catch (Exception ex) {
    
      } finally {
       if (user != null) {
        user.Undo();
       }
       if (token != IntPtr.Zero) {
        CloseHandle(token);
       }
      }
     }
    }
