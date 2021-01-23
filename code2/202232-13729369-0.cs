    Try
          //Your code
    Catch ex As Exception
          MessageBox.Show(ex.GetBaseException().Message, My.Settings.MsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
    End Try
