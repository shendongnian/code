    ' Get the AppSettings section.        
    ' This function uses the AppSettings property
    ' to read the appSettings configuration 
    ' section.
    Public Shared Sub ReadAppSettings()
        Try
            ' Get the AppSettings section.
            Dim appSettings As NameValueCollection = _
                ConfigurationManager.AppSettings
    
            ' Get the AppSettings section elements.
            Console.WriteLine()
            Console.WriteLine("Using AppSettings property.")
            Console.WriteLine("Application settings:")
    
            If appSettings.Count = 0 Then
                Console.WriteLine( _
                "[ReadAppSettings: {0}]", _
                "AppSettings is empty Use GetSection first.")
            End If
            Dim i As Integer = 0
            While i < appSettings.Count
                Console.WriteLine( _
                    "#{0} Key: {1} Value: {2}", _
                    i, appSettings.GetKey(i), appSettings(i))
                System.Math.Max( _
                    System.Threading.Interlocked. _
                    Increment(i), i - 1)
            End While
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[ReadAppSettings: {0}]", _
                              e.ToString())
        End Try
    End Sub
