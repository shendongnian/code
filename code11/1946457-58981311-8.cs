       Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
          If e.Button = MouseButtons.Left Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.HitTest(e.X, e.Y)
            If ht.ColumnIndex>=0 AndAlso Me.Columns(ht.ColumnIndex).Selected Then
                ColDragInProgress = True
                SelectedColumns = StoreAllSelectedCols()
            Else
                ColDragInProgress = False
                MyBase.OnMouseDown(e)
            End If
          Else
            MyBase.OnMouseDown(e) 'in all other cases call the base function
          End If
        End Sub
