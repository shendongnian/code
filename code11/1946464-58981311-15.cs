    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
      If ColDragInProgress AndAlso e.Button = Windows.Forms.MouseButtons.Left  Then
        Dim dropEffect As DragDropEffects = Me.DoDragDrop(SelectedColumns, DragDropEffects.Copy)
      Else
        MyBase.OnMouseMove(e) 'let's do the base class the rest
      End If
    End Sub
