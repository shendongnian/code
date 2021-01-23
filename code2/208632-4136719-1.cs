    Imports System.IO
    Imports System.IO.Packaging
    Public Class clsCompression
        Const BUFFER_SIZE As Long = 4096
        Sub New()
        End Sub
        Public Function AddFileToZip(ByVal zipFilename As String, _
                                     ByVal fileToAdd As String, _
                                     ByVal directoryFile As String) As Boolean
            Dim trace As String = ""
            Try
                trace = String.Format("{0} AddFileToZip zipFilename: '{1}' fileToAdd: '{2}'{3}", _
                                      Now, zipFilename, fileToAdd, vbNewLine)
                Using zip As Package = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate)
                    Dim destFilename As String = ".\" & directoryFile & "\" & Path.GetFileName(fileToAdd)
                    Dim uri As Uri = PackUriHelper.CreatePartUri(New Uri(destFilename, UriKind.Relative))
                    If zip.PartExists(uri) Then
                        zip.DeletePart(uri)
                    End If
                    Dim part As PackagePart = zip.CreatePart(uri, "", CompressionOption.Normal)
                    Using fileStream As New FileStream(fileToAdd, FileMode.Open, FileAccess.Read)
                        Using dest As Stream = part.GetStream()
                            CopyStream(fileStream, dest)
                        End Using
                    End Using
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function AddFileToZip(ByVal zipFilename As String, ByVal fileToAdd As String) As Boolean
            Dim trace As String = ""
            Try
                trace = String.Format("{0} AddFileToZip zipFilename: '{1}' fileToAdd: '{2}'{3}", _
                                      Now, zipFilename, fileToAdd, vbNewLine)
                Using zip As Package = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate)
                    Dim destFilename As String = ".\" & Path.GetFileName(fileToAdd)
                    Dim uri As Uri = PackUriHelper.CreatePartUri(New Uri(destFilename, UriKind.Relative))
                    If zip.PartExists(uri) Then
                        zip.DeletePart(uri)
                    End If
                    Dim part As PackagePart = zip.CreatePart(uri, "", CompressionOption.Normal)
                    Using fileStream As New FileStream(fileToAdd, FileMode.Open, FileAccess.Read)
                        Using dest As Stream = part.GetStream()
                            CopyStream(fileStream, dest)
                        End Using
                    End Using
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Sub CopyStream(ByVal inputStream As System.IO.FileStream, ByVal outputStream As System.IO.Stream)
            Dim bufferSize As Long = If(inputStream.Length < BUFFER_SIZE, inputStream.Length, BUFFER_SIZE)
            Dim buffer As Byte() = New Byte(CInt(bufferSize) - 1) {}
            Dim bytesRead As Integer = 0
            Dim bytesWritten As Long = 0
            While (InlineAssignHelper(bytesRead, inputStream.Read(buffer, 0, buffer.Length))) <> 0
                outputStream.Write(buffer, 0, bytesRead)
                bytesWritten += bufferSize
            End While
        End Sub
        Private Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
    End Class
