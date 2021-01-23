    Public Module DirectoryExtensions
        <Runtime.CompilerServices.Extension()>
        Public Function GetSubFolders(ByVal rootFolder As DirectoryInfo, withEndPoints As Boolean) As List(Of DirectoryInfo)
            If rootFolder Is Nothing Then
                Throw New ArgumentException("Root-Folder must not be null!", "rootFolder")
            End If
    
            Dim subFolders As New List(Of DirectoryInfo)
            AddSubFoldersRecursively(rootFolder, withEndPoints, subFolders)
            Return subFolders
        End Function
    
        Private Sub AddSubFoldersRecursively(rootFolder As DirectoryInfo, withEndPoints As Boolean, ByRef allFolders As List(Of DirectoryInfo))
            Try
                Dim subFolders = rootFolder.GetDirectories
                If withEndPoints OrElse subFolders.Count <> 0 Then
                    allFolders.Add(rootFolder)
                    For Each subFolder In subFolders
                        AddSubFoldersRecursively(subFolder, withEndPoints, allFolders)
                    Next
                End If
           Catch exUnauthorized As UnauthorizedAccessException
               ' go on '
           Catch exNotFound As DirectoryNotFoundException
               ' go on '
           Catch ex As Exception
               Throw
           End Try
        End Sub
    End Module
