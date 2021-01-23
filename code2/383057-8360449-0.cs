    ''' <summary>
    ''' This method streams a file to a user
    ''' </summary>
    ''' <param name="cMimeTypes">The set of known mimetypes. This is only needed when the file is not being downloaded.</param>
    ''' <param name="sFileName"></param>
    ''' <param name="sFileNameForUser"></param>
    ''' <param name="theResponse"></param>
    ''' <param name="fDownload"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StreamFileToUser(ByVal cMimeTypes As StringItemCollection, ByVal sFileName As String, ByVal sFileNameForUser As String, ByVal theResponse As HttpResponse, Optional ByVal fDownload As Boolean = True, Optional fOkToDeleteFile As Boolean = False) As Boolean
        ' Exceptions are handled by the caller
    
        Dim fDontEndResponse As Boolean
    
        sFileNameForUser = CleanFileName(sFileNameForUser)
    
        ' Ensure there is nothing else in the response
        With theResponse
            Try
                Try
                    ' Remove what other controls may have been put on the page
                    .ClearContent()
                    ' Clear any headers
                    .ClearHeaders()
                Catch theException As System.Web.HttpException
                    ' Ignore this exception, which could occur if there were no HTTP headers in the response
                End Try
    
                Dim fFoundIt As Boolean
    
                If Not fDownload Then
                    Dim sMimeType As StringItem
                    Dim sExtension As String
    
                    sExtension = IO.Path.GetExtension(sFileNameForUser)
                    If Not String.IsNullOrEmpty(sExtension) Then
                        sExtension = sExtension.Replace(".", "")
                        sMimeType = cMimeTypes.Item(sExtension)
                        If sMimeType IsNot Nothing Then
                            .ContentType = sMimeType.Value
                            .AddHeader("Content-Disposition", "inline; filename=" & sFileNameForUser)
                            fFoundIt = True
                        End If
                    End If
                End If
    
                If Not fFoundIt Then
                    .ContentType = "application/octet-stream"
                    .AddHeader("Content-Disposition", "attachment; filename=" & sFileNameForUser)
                End If
    
                .TransmitFile(sFileName)
    
                ' Ensure the file is properly flushed to the user
                .Flush()
            Finally
                ' If the caller wants, delete the file before the response is terminated
                If fOkToDeleteFile Then
                    Call KillAFile(sFileName)
                End If
            End Try
    
            ' Ensure the response is closed
            .Close()
    
            If Not fDontEndResponse Then
                Try
                    .End()
                Catch
                End Try
            End If
        End With
    
        Return True
    End Function
