     Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
    
            Try
                If RichTextBox1.SelectedText <> "" Then
                    Clipboard.SetData(DataFormats.Rtf,RichTextBox1.SelectedRtf)
                    RichTextBox1.SelectedRtf = ""
                Else
                    MsgBox("No item is selected to cut", MsgBoxStyle.Information, "Cut")
                End If
            Catch ex As Exception
                MsgBox("Can't cut the selected item", MsgBoxStyle.Critical, "Cut")
            End Try
        End Sub
