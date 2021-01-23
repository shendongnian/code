    Public Module DirectoryExtensions
        <Runtime.CompilerServices.Extension()>
        Public Function GetSubFolders(ByVal rootFolder As DirectoryInfo) As List(Of DirectoryInfo)
            If rootFolder Is Nothing Then
                Throw New ArgumentException("Root-Folder must not be null!", "rootFolder")
            End If
    
            Dim subFolders As New List(Of DirectoryInfo)
            AddSubFoldersRecursively(rootFolder, subFolders)
            Return subFolders
        End Function
    
        Private Sub AddSubFoldersRecursively(rootFolder As DirectoryInfo, ByRef allFolders As List(Of DirectoryInfo))
            Try
                allFolders.Add(rootFolder)
                For Each subFolder In rootFolder.GetDirectories
                    AddSubFoldersRecursively(subFolder, allFolders)
                Next
           Catch exUnauthorized As UnauthorizedAccessException
               ' go on '
           Catch exNotFound As DirectoryNotFoundException
               ' go on '
           Catch ex As Exception
               Throw
           End Try
        End Sub
    End Module
