    Protected Function GetRadioButtonGroup(ByVal control As Control, ByVal groupName As String) As RadioButton()
        Dim rbList As New System.Collections.Generic.List(Of RadioButton)
        If TypeOf control Is RadioButton AndAlso DirectCast(control, RadioButton).GroupName = groupName Then
            rbList.Add(control)
        End If
        If control.HasControls Then
            For Each subcontrol As Control In control.Controls
                rbList.AddRange(GetRadioButtonGroup(subcontrol, groupName))
            Next
        End If
        Return rbList.ToArray
    End Function
