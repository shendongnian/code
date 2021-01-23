    Private mRegShellPath="Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
    Private mCommonDesktop = Nothing
    ' dgp rev 3/8/2012
    Private ReadOnly Property CommonDesktop As String
        Get
            If mCommonDesktop Is Nothing Then
                Dim RegKey As RegistryKey
                Try
                    RegKey = Registry.LocalMachine.OpenSubKey(mRegShellPath, False)
                    mCommonDesktop = RegKey.GetValue("Common Desktop")
                Catch ex As Exception
                    mCommonDesktop = ""
                End Try
            End If
            Return mCommonDesktop
        End Get
    End Property
