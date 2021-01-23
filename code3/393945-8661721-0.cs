    Private Sub ShowControl(ByVal fromControl As Control, ByVal whichControl As Control)
      '\\ whichControl needs MinimumSize set:'
      whichControl.MinimumSize = whichControl.Size
    
      Dim toolDrop As New ToolStripDropDown()
      Dim toolHost As New ToolStripControlHost(whichControl)
      toolHost.Margin = New Padding(0)
      toolDrop.Padding = New Padding(0)
      toolDrop.Items.Add(toolHost)
      toolDrop.Show(Me, New Point(fromControl.Left, fromControl.Bottom))
    End Sub
