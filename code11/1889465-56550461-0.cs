    Private Sub progSelectProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progSelectProgramButton.Click
        Try
            m_objCMDProgram.SelectMainProgram(prog1.Text, prog2.Text, prog3.Text, prog4.Text)
        Catch ae As ApplicationException
            DisplayError("CMD program", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub
