    Public Partial Class Redirector
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim OpenNewPage As String = ""
            If Request.QueryString("goto") IsNot Nothing Then
                Me.OpenNewPage = Request.QueryString("goto")
            End If
            If Request.UrlReferrer.AbsoluteUri IsNot Nothing Then
                Me.Referer = Request.UrlReferrer.AbsoluteUri
            End If
        End Sub
    
        Private _OpenNewPage As String = ""
        Public Property OpenNewPage() As String
            Get
                Return _OpenNewPage
            End Get
            Set(ByVal value As String)
                _OpenNewPage = value
            End Set
        End Property
    
        Private _Referer As String = ""
        Public Property Referer() As String
            Get
                Return _Referer
            End Get
            Set(ByVal value As String)
                _Referer = value
            End Set
        End Property
    
    End Class
