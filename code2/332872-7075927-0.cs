       Sub OnAction(control As IRibbonControl, id As String, index As Integer)
        If (control.Tag = "large") Then
            id = Strings.Mid(id, 3)
        End If
        
        Dim form As New ControlInfoForm
        form.nameX.Caption = "imageMso: " & id
        Set form.Image1.Picture = Application.CommandBars.GetImageMso(id, 16, 16)
        Set form.Image2.Picture = Application.CommandBars.GetImageMso(id, 32, 32)
        form.Show
    End Sub
