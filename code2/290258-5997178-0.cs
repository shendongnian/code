    For Each property as Google.GData.Client.IExtensionElementFactory In googleEvent.ExtensionElements
         Dim customProperty As ExtendedProperty = CType(property, ExtendedProperty)
         If customerProperty IsNot Nothing Then
              genericEvent.EventID = customProperty.Value
         End If
    Next
