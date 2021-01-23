    Public Class Repeater
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim dt As DataTable = New DataItem().GetData()
                rpt1.DataSource = dt
                rpt1.DataBind()
            End If
        End Sub
    
        Protected Function WrapTitle(ByVal title As Object, ByVal lnk As Object) As String
            If Not String.IsNullOrWhiteSpace(lnk.ToString()) Then
                Return String.Format("<a href='{0}'>{1}</a>", lnk, title)
            End If
            Return title.ToString()
        End Function
    
        Protected Function GetUrl(ByVal img As String) As String
    
            Return Page.ResolveUrl("~/Images/") + img
        End Function
    
    End Class
    
    Public Class DataItem
        Private lnks() As String = {"http://www.google.com", "http://www.yahoo.com", "http://www.bing.com", "http://www.superuser.com", "http://www.stackoverflow.com", ""}
        Private titles() As String = {"Google", "Yahoo", "Bing", "superuser", "stackoverflow", "ask.com"}
        Private images() As String = {"nav_logo91.png", "yahoo.png", "bing.png", "superuser.png", "stackoverflow.png", ""}
    
        Public Function GetData() As DataTable
            Dim dtb As New DataTable
            dtb.Columns.Add("title")
            dtb.Columns.Add("link")
            dtb.Columns.Add("Image")
    
            For i As Integer = 0 To titles.Length - 1
                dtb.Rows.Add(New Object() {titles(i), lnks(i), images(i)})
            Next
    
            Return dtb
        End Function
    
    End Class
