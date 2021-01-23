    // obtain the process id of the winlogon process that 
    // is running within the currently active session
    Process[] processes = Process.GetProcessesByName("winlogon");
    foreach (Process p in processes)
    {
        if ((uint)p.SessionId == dwSessionId)
        {
            winlogonPid = (uint)p.Id;
        }
    }
    // obtain a handle to the winlogon process
    hProcess = OpenProcess(MAXIMUM_ALLOWED, false, winlogonPid);
    // obtain a handle to the access token of the winlogon process
    if (!OpenProcessToken(hProcess, TOKEN_DUPLICATE, ref hPToken))
    {
        CloseHandle(hProcess);
        return false;
    }
    // Security attibute structure used in DuplicateTokenEx and   CreateProcessAsUser
    // I would prefer to not have to use a security attribute variable and to just 
    // simply pass null and inherit (by default) the security attributes
    // of the existing token. However, in C# structures are value types and   therefore
    // cannot be assigned the null value.
    SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
    sa.Length = Marshal.SizeOf(sa);
    // copy the access token of the winlogon process; 
    // the newly created token will be a primary token
    if (!DuplicateTokenEx(hPToken, MAXIMUM_ALLOWED, ref sa, 
        (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, 
        (int)TOKEN_TYPE.TokenPrimary, ref hUserTokenDup))
        {
          CloseHandle(hProcess);
          CloseHandle(hPToken);
          return false;
        }
     STARTUPINFO si = new STARTUPINFO();
     si.cb = (int)Marshal.SizeOf(si);
    // interactive window station parameter; basically this indicates 
    // that the process created can display a GUI on the desktop
    si.lpDesktop = @"winsta0\default";
    // flags that specify the priority and creation method of the process
    int dwCreationFlags = NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE;
    // create a new process in the current User's logon session
     bool result = CreateProcessAsUser(hUserTokenDup,  // client's access token
                                null,             // file to execute
                                applicationName,  // command line
                                ref sa,           // pointer to process    SECURITY_ATTRIBUTES
                                ref sa,           // pointer to thread SECURITY_ATTRIBUTES
                                false,            // handles are not inheritable
                                dwCreationFlags,  // creation flags
                                IntPtr.Zero,      // pointer to new environment block 
                                null,             // name of current directory 
                                ref si,           // pointer to STARTUPINFO structure
                                out procInfo      // receives information about new process
                                );
