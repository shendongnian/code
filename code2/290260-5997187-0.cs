    For Each [property] As Google.GData.Client.IExtensionElementFactory In googleEvent.ExtensionElements
        Dim customProperty as ExtendedProperty = [property]
        If customProperty IsNot Nothing Then
            genericEvent.EventID = customProperty.Value
        End If
    Next
