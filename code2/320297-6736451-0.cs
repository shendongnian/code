    object settingsObject = property.GetValue(_theObject, null);
    dictionary.Add(
        property.Name,
        settingsObject.GetType().GetProperty("Value")
                                .GetValue(settingsObject, null));
