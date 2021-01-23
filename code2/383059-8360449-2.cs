    ''' <summary>
    ''' This method generates a standard list of extension to content-disposition tags
    ''' The key for each item is the file extension without the leading period. The value 
    ''' is the content-disposition.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GenerateStandardMimeList() As StringItemCollection
        ' Exceptions are handled by the caller.
    
        Dim cItems As New StringItemCollection
    
        cItems.AddNewRecord("jpeg", "image/jpeg")
        cItems.AddNewRecord("jpg", "image/jpeg")
        cItems.AddNewRecord("pdf", "application/pdf")
    End Function
