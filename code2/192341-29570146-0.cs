    Private Sub ckl_ItemCheck(ByVal sender As Object, _
                              ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles ckl.ItemCheck
    tmr.Enabled = False
    tmr.Enabled = True
    End Sub
    Private Sub tmr_Tick(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) _
        Handles tmr.Tick
    tmr.Enabled = False
    Debug.Write(ckl.SelectedIndex)
    Debug.Write(": ")
    Debug.WriteLine(ckl.GetItemChecked(ckl.SelectedIndex).ToString)
    End Sub
