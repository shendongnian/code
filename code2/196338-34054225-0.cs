    Public Class frmDocEntry
        ...
        Private lastIdx As Integer = -1
        ...
        Private Sub cbAnyMV_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRGBStringMV.Enter, cbRGBIntegerMV.Enter, cbRGBFloatMV.Enter, cbRGBDateMV.Enter
            ' comboBox.SelectedIndex will get *reset* to -1 by text edit
            lastIdx = sender.SelectedIndex
        End Sub
    
        Private Sub cbAnyMV_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRGBStringMV.Leave, cbRGBIntegerMV.Leave, cbRGBFloatMV.Leave, cbRGBDateMV.Leave
            If lastIdx >= 0 Then
                sender.Items(lastIdx) = sender.Text
            End If
            lastIdx = -1
        End Sub
    
        Private Sub cbAnyMV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRGBStringMV.SelectedIndexChanged, cbRGBIntegerMV.SelectedIndexChanged, cbRGBFloatMV.SelectedIndexChanged, cbRGBDateMV.SelectedIndexChanged
            lastIdx = sender.SelectedIndex
        End Sub
