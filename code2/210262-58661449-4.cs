     Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
    
            Try
                If RichTextBox1.SelectedText <> "" Then
                    Clipboard.SetData(DataFormats.Rtf,RichTextBox1.SelectedRtf)
                Else
                    MsgBox("No item is selected to copy", MsgBoxStyle.Information, "Copy")
                End If
            Catch ex As Exception
                MsgBox("Can't copy the selected item", MsgBoxStyle.Critical, "Copy")
            End Try
        End Sub
