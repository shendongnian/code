     Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
    
            Try
                If Clipboard.ContainsText(TextDataFormat.Rtf) Then
                    RichTextBox1.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString()
                ElseIf Clipboard.ContainsText(TextDataFormat.Text) Then
                    RichTextBox1.SelectedText = Clipboard.GetData(DataFormats.Text).ToString()
                Else
                    MsgBox("Clipboard is not contained with the valid text format ", MsgBoxStyle.Information, "Paste")
                End If
            Catch ex As Exception
                MsgBox("Can't paste the item", MsgBoxStyle.Critical, "Paste")
            End Try
        End Sub
