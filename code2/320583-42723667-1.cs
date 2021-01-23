    var customProp1 = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings,
                            "myCustomPropOne", MapiPropertyType.String);
    var customProp2 = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings,
                          "myCustomPropTwo", MapiPropertyType.String);
    var userFields = new ExtendedPropertyDefinition[] { customProp1, customProp2 };
    var extendedPropertySet = new PropertySet(BasePropertySet.FirstClassProperties, userFields);
    var contactItems = service.FindItems(WellKnownFolderName.Contacts, new ItemView(100)
                { PropertySet = new PropertySet(BasePropertySet.FirstClassProperties, extendedPropertySet) });
    // Looping contacts
        foreach (Item item in contactItems){
            object firstProp;              
            if (item.TryGetProperty(customProp1, out firstProp) && firstProp != null)
            {
                   var val = firstProp.ToString();
            }
            object secondProp;
            if (item.TryGetProperty(customProp2, out secondProp) && secondProp != null)
            {
                   var val = secondProp.ToString();
            }
         } // loop ends
