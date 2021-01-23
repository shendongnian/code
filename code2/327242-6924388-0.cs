    Protected Sub rptArticleContent_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptArticleContent.ItemDataBound
    
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
    
                Dim Links As String = e.Item.DataItem("Links")
                Dim LinksStr As String() = Links.Split(";")
                Dim Ltl As Literal = e.Item.FindControl("Ltl")
                Dim Inc As Integer = 1
                For Each item As String In LinksStr
                    Ltl.Text += String.Format("<a href='{0}'>Link {1}</a>", item, Inc)
                    Inc += 1
                Next
    
        End Select
    
    End Sub
