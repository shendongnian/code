    Public Sub addTabPage(ByVal Title As String)
        Dim TPage As New TabPage(Title)
        Dim UCInstance As New UControl()
        TPage.Controls.Add(UCInstance)
        TabControl1.TabPages.Add(TPage)
        UCInstance.Dock = DockStyle.Fill
    End Sub
