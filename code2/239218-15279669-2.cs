    Private associatedLabels As New Dictionary(Of Control, Label)    
    <Extension()>
    Public Sub AssociateLabel(ByVal control As Control, ByVal label As Label)
        If (Not associatedLabels.ContainsKey(control)) Then
            associatedLabels.Add(control, label)
        End If
    End Sub
    <Extension()>
    Public Function GetAssociatedLabel(ByVal control As Control) As Label
        If (associatedLabels.ContainsKey(control)) Then
            Return associatedLabels(control)
        Else
            Throw New Exception("There is no associated label")
        End If
    End Function
