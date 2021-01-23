    For Each elem As Google.GData.Client.IExtensionElementFactory In googleEvent.ExtensionElements
        Dim customProperty As ExtendedProperty = DirectCast(elem, ExtendedProperty)
        If ExtendedProperty IsNot Nothing Then
            genericEvent.EventID = customProperty.Value
        End If
    Next
