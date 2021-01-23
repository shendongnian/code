    <Extension()>
    Public Sub AssociateLabel(ByVal control As Control, ByVal label As Label)
        control.Controls.Add(label)
    End Sub
    <Extension()>
    Public Function GetAssociatedLabel(ByVal control As Control) As Label
        Dim labelReturn As Label = (From c As Control In control.Controls
                                    Where TypeOf (c) Is Label).FirstOrDefault()
        If (labelReturn Is Nothing) Then
            Throw New Exception("There is no associated label")
        End If
        Return labelReturn
    End Function
