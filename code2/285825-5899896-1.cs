    Private Sub Label1_DragDrop(ByVal sender As Object, _
               ByVal e As System.Windows.Forms.DragEventArgs) Handles Label1.DragDrop
        'Get the data being dropped from e.Data and do something.
    End Sub
    Private Sub Label1_DragEnter(ByVal sender As Object, _
              ByVal e As System.Windows.Forms.DragEventArgs) Handles Label1.DragEnter
        'e.Effect controls what type of DragDrop operations are allowed on the label.
        'You can also check the type of data that is being dropped on the label here
        'by checking e.Data.
        e.Effect = DragDropEffects.All
    End Sub
