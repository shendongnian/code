       Public Function JSE_IsSystemRestoreEnabled() As Boolean
            Dim rk As RegistryKey = JSE_ReadRegistry()
            Dim rk1 As RegistryKey = rk.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore")
            Dim strRestore As String = rk1.GetValue("RPSessionInterval").ToString()
            If strRestore.Contains("1") Then
                Debug.Print("System Restore is Enabled")
                Return True
            ElseIf strRestore.Contains("0") Then
                Debug.Print("System Restore is Disabled")
                Return False
            Else
                Debug.Print("IsSystemRestoreEnabled(): No Idea, JACK!")
                Return False
            End If
        End Function
