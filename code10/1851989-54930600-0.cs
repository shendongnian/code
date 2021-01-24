    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyValue = Keys.Down Then
            With Me.DataGridView1
                If .Columns(.CurrentCell.ColumnIndex).GetType.Name = "DataGridViewComboBoxColumn" Then
                    If Not .IsCurrentCellInEditMode Then
                        .BeginEdit(True)
                        CType(.EditingControl, ComboBox).DroppedDown = True
                        e.Handled = True
                    End If
                End If
            End With
        End If
    End Sub
