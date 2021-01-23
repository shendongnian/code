        Friend Shared Function DomainComputers() As Generic.List(Of String)
        ' Add a Reference to System.DirectoryServices
        Dim Result As New Generic.List(Of String)
        Dim ComputerName As String = Nothing
        Dim SRC As SearchResultCollection = Nothing
        Dim Searcher As DirectorySearcher = Nothing
        Try
            Searcher = New DirectorySearcher("(objectCategory=computer)", {"Name"})
            Searcher.Sort = New SortOption("Name", SortDirection.Ascending)
            Searcher.Tombstone = False
            SRC = Searcher.FindAll
            For Each Item As SearchResult In SRC
                ComputerName = Item.Properties("Name")(0)
                Result.Add(ComputerName)
            Next
        Catch ex As Exception
        End Try
        Return Result
    End Function
