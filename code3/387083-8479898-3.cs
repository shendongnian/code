    Private Sub DdlTabs_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DdlTabs.SelectedIndexChanged
        Select Case DdlTabs.SelectedValue
            Case "Tab1"
                Me.TabContainer1.ActiveTabIndex = 0
            Case "Tab2"
                Me.TabContainer1.ActiveTabIndex = 1
            Case "Tab3"
                Me.TabContainer1.ActiveTabIndex = 2
        End Select
        Me.UpdTabContainer.Update()
    End Sub
    Private Sub TabContainer1_ActiveTabChanged(sender As Object, e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        Select Case TabContainer1.ActiveTabIndex
            Case 0
                Me.DdlTabs.SelectedValue = "Tab1"
            Case 1
                Me.DdlTabs.SelectedValue = "Tab2"
            Case 2
                Me.DdlTabs.SelectedValue = "Tab3"
        End Select
        Me.UpdDdlTabs.Update()
    End Sub
