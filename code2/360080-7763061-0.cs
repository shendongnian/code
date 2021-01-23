    Partial Class MyPage
      Inherits System.Web.UI.Page
      Protected lbl As Label
      Private Sub Page_Load(sender As Object, e As EventArgs)
        If Not Page.IsPostback Then
          lbl = New Label()
          lbl.ID = "lbl"
          Me.Controls.Add(lbl)
        End If
      End Sub
    End Class
