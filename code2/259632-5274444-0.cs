    private bool needToInjectMacroCode() {
        // Get custom document property with name tagPropertyName
        
        object properties, property, propertyValue;
        properties = excel.ActiveWorkbook.GetType().InvokeMember(
            "CustomDocumentProperties",
            BindingFlags.Default | BindingFlags.GetProperty,
            null, excel.ActiveWorkbook, null);
        try {
            property = properties.GetType().InvokeMember(
                "Item",
                BindingFlags.Default | BindingFlags.GetProperty,
                null, properties, new object[] { tagPropertyName });
        } catch (TargetInvocationException) {
            return true;
        }
        propertyValue = property.GetType().InvokeMember(
            "Value",
            BindingFlags.Default | BindingFlags.GetProperty,
            null, property, null);
        return (tagString != (propertyValue as string));
    }
    
    // ...
    private void setMacroCodeInjected() {
        // Set custom property with name tagPropertyName to value tagString
        
        object properties = excel.ActiveWorkbook.GetType().InvokeMember(
            "CustomDocumentProperties",
            BindingFlags.Default | BindingFlags.GetProperty,
            null, excel.ActiveWorkbook, null);
        try {
            properties.GetType().InvokeMember(
                "Add",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null, properties, new object[] {
                    tagPropertyName, false,
                    Office.MsoDocProperties.msoPropertyTypeString,
                    tagString
                });
        } catch (TargetInvocationException) {
            object property = properties.GetType().InvokeMember(
                "Item",
                BindingFlags.Default | BindingFlags.GetProperty,
                null, properties, new object[] { tagPropertyName });
            property.GetType().InvokeMember(
                "Value",
                BindingFlags.Default | BindingFlags.SetProperty,
                null, property, new object[] { tagString });
        }
    }
