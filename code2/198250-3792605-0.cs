    Public Function GetElements(ByVal TagName As String, ByVal ClassName As String) As List(Of XElement)
        Dim Document = XDocument.Load("http://urlofyourchoice.net/")
        Dim Elements = Document.Descendants().Where(Function(e) e.Name.LocalName = TagName AndAlso e.Attribute("class") = ClassName)
    
        Return Elements.ToList
    End Function
    
    Sub Usage() Handles Me.Load
        Response.Write(GetElements("div", "ContentBox").First.ToString())
    End Sub
