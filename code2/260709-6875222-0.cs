    Private Sub Child_ParentChanged(sender As Object, e As System.EventArgs) Handles Me.ParentChanged
        Try
            ToolStripManager.Merge(Me.ToolStrip, TryCast(sender.mdiParent, frmMain).ToolStrip)
        Catch ex As Exception
            mErrorLog.ApplicationErrorLog(Me.GetType.Name, "frmTechSelectWO_ParentChanged", ex.ToString)
        Finally
            Me.ToolStrip.Hide()
            Me.MenuStrip1.Hide()
        End Try
    End Sub
    Private Sub Child_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '
        ' Clean up the parent toolbar
        Try
            ToolStripManager.RevertMerge(TryCast(Me.MdiParent, frmMain).ToolStrip)
        Catch ex As Exception
        End Try
    End Sub
