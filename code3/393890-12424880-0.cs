     Public Sub New()
            InitializeComponent()
            MyDataGridViewInitializationMethod()
        End Sub
        Private Sub MyDataGridViewInitializationMethod()
            AddHandler dataGridView1.EditingControlShowing, AddressOf dataGridView1_EditingControlShowing
        End Sub
        Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
            AddHandler e.Control.KeyPress, AddressOf Control_KeyPress
        End Sub
        Dim dotOnce As Boolean
        Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            If e.KeyChar Like "[']" Then
                e.Handled = True
                Exit Sub
            End If
            If e.KeyChar = "." Then
                If dotOnce Then
                    e.Handled = True
                End If
                dotOnce = True
            Else
               If (Not e.KeyChar Like "[0-9 . ]") Then
                    e.Handled = True
                    Exit Sub
                End If
            End If
              End Sub
