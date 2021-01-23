Imports SevenZip<BR>
Public Class FrmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        ''Call to set DLL depending on proccessor type''
        If Environment.Is64BitProcess Then
            SevenZip.SevenZipCompressor.SetLibraryPath("7zx64.dll")
        Else
            SevenZip.SevenZipCompressor.SetLibraryPath("7z.dll")
        End If
        ''Set Destination of extraction''
        Dim DestDir = Application.StartupPath
        Try
            ''Check file with password''
            Dim Ext As New SevenZipExtractor(Tb1.Text, Tb2.Text)
            If Ext.Check() Then
                ''Extract files to destination''
                Ext.BeginExtractArchive(DestDir)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
