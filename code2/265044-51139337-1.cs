    Private Sub browser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles browser.Navigating
        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case e.Url.Scheme
                Case Constants.App_Url_Scheme
                    Dim query As Specialized.NameValueCollection = System.Web.HttpUtility.ParseQueryString(e.Url.Query)
                    Select Case e.Url.Host
                        Case Constants.Navigation.URLs.ToggleExpander.Host
                            Dim nodeID As String = query.Item(Constants.Navigation.URLs.ToggleExpander.Parameters.NodeID)
                            :
                            :
                            <other operations here>
                            :
                            :
                    End Select
                Case Else
                    e.Cancel = (e.Url.ToString() <> "about:blank")
            End Select
        Catch ex As Exception
            ExceptionBox.Show(ex, "Operation failed.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
