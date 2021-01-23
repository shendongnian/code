    <System.Runtime.CompilerServices.Extension()>
    Public Function Search(query As IQueryable(Of Customer), searchTerm As String) As IQueryable(Of Customer)
        Dim queryWords = searchTerm.Split(" ")
    
        For Each w In queryWords
            Dim word = w
            Dim packedWord = Pack(word)
    
            query = query.Where(Function(c) c.FirstName = word OrElse
                                    c.LastName = word OrElse
                                    c.HomePhone = packedWord OrElse
                                    c.CellPhone = packedWord)
        Next
        Return query
    End Function
