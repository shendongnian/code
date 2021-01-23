    switch(GetExeType( file )) {
        case ShellFileGetInfo.ShellFileType.Unknown:
            System.Diagnostics.Debug.WriteLine( "Unknown: " + file );
            break;
        case ShellFileGetInfo.ShellFileType.Dos:
            System.Diagnostics.Debug.WriteLine( "DOS: " + file );
            break;
        case ShellFileGetInfo.ShellFileType.Windows:
            System.Diagnostics.Debug.WriteLine( "Windows: " + file );
            break;
        case ShellFileGetInfo.ShellFileType.Console:
            System.Diagnostics.Debug.WriteLine( "Console: " + file );
            break;
        case ShellFileGetInfo.ShellFileType.FileNotFound:
            System.Diagnostics.Debug.WriteLine( "Missing: " + file );
            break;
    }
