    '------------------------------------------------------
    ' Declaration found in Microsoft.Win32.Win32Native
    '------------------------------------------------------
    Friend Declare Auto Function GetVolumeInformation Lib "kernel32.dll" (drive As String, <Out()> volumeName As StringBuilder, volumeNameBufLen As Integer, <Out()> ByRef volSerialNumber As Integer, <Out()> ByRef maxFileNameLen As Integer, <Out()> ByRef fileSystemFlags As Integer, <Out()> fileSystemName As StringBuilder, fileSystemNameBufLen As Integer) As Boolean
    '------------------------------------------------------
    ' Test in my Form class
    '------------------------------------------------------
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            Dim volumeName As StringBuilder = New StringBuilder(50)
            Dim stringBuilder As StringBuilder = New StringBuilder(50)
            Dim volSerialNumber As Integer
            Dim maxFileNameLen As Integer
            Dim fileSystemFlags As Integer
            If Not GetVolumeInformation("C:\", volumeName, 50, volSerialNumber, maxFileNameLen, fileSystemFlags, stringBuilder, 50) Then
                Dim lastWin32Error As Integer = Marshal.GetLastWin32Error()
                MsgBox("Error number:" & lastWin32Error)
            Else
                MsgBox(volSerialNumber.ToString("X"))
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
