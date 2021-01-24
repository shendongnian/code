`
protected HtmlGenericControl TitleLogo;
private void Page_Load(object sender, System.EventArgs e)
{
   if(!Page.IsPostBack)
   {
      TitleLogo.Attributes["href"] = "Images/TM33.ico";
   }
}    
`
And in VB
`
    Protected TitleLogo As HtmlGenericControl
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not Page.IsPostBack Then
            TitleLogo.Attributes("href") = "Images/TM33.ico"
        End If
    End Sub
`
