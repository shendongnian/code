    model.Attributes = new Dictionary<string, object>();
    model.Attributes.Add(@"class", "test");
    if (isDisabled) {
        model.Attributes.Add("disabled", "true");
    }
