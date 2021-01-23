    Private Sub OKCmd_Click( _
      ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles OKCmd.Click
    	
        If Not ____do_your_test_here____ Then
          MsgBox("Cannot press OK because of blah blah blah . Try again.", MsgBoxStyle.Exclamation)
        Else
          Me.DialogResult = DialogResult.OK
          Me.Close()
        End If
    End Sub
