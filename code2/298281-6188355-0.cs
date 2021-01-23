    System.Diagnostics.Process externalProcess = new System.Diagnostics.Process( )
    {
        StartInfo = new System.Diagnostics.ProcessStartInfo( appToHost )
    };
    externalProcess.Start( );
    externalProcess.WaitForInputIdle( );
    if ( !externalProcess.HasExited )
    {
        ShowWindow( externalProcess.MainWindowHandle, ShowWindowStyle.Maximize );
        SetParent( externalProcess.MainWindowHandle, panel.Handle );
    }
