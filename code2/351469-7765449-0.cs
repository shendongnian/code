    Private Sub SearchLookUpEdit1_Popup(sender As System.Object, _
            e As System.EventArgs) Handles SearchLookUpEdit1.Popup
        Dim popupControl As Control = CType(sender, IPopupControl).PopupWindow
        popupControl.BackColor = Color.LightBlue
        Dim lc As LayoutControl = CType(popupControl.Controls(2).Controls(0), LayoutControl)
        Dim lcgroup As LayoutControlGroup = CType(lc.Items(0), LayoutControlGroup)
        lcgroup.AppearanceGroup.BackColor = Color.LightBlue
    End Sub
