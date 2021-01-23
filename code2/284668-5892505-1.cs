    Private dgTextbox As TextBox = New TextBox
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
    
        RemoveHandler dgTextbox.KeyPress, AddressOf dgTextbox_KeyPress
        dgTextbox = CType(e.Control, TextBox)
        AddHandler dgTextbox.KeyPress, AddressOf dgTextbox_KeyPress
    End Sub
    Private Sub dgTextbox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'your code goes here
    End Sub
