        Private Sub RepositoryItemTextEditDescrip_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemTextEditDescrip.EditValueChanging
        Static lbl As New DevExpress.XtraEditors.LabelControl
        Dim tx As DevExpress.XtraEditors.TextEdit = sender
        Dim s As String = e.NewValue ' tx.Text
        lbl.Text = e.NewValue.ToString.Split(vbCr)(0)
        lbl.Font = tx.Font
        If lbl.PreferredSize.Width >= colDescrip.Width - 15 Then
            Do Until lbl.PreferredSize.Width <= colDescrip.Width - 15 Or s.Length = 0
                s = s.Remove(s.Length - 1)
                lbl.Text = s
            Loop
        End If
        Dim i As Integer = tx.SelectionStart
        e.NewValue = s
        BeginInvoke(New Action(Of TextEdit, Integer)(AddressOf sbTxSelectIndx), New Object() {tx, i})
    End Sub
    Private Sub sbTxSelectIndx(ByVal tx As TextEdit, ByVal i As Integer)
        tx.Select(i, 0)
    End Sub
