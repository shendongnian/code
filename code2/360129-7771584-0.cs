    protected void UpdateIfChanged(Field field, string value)
    {
        if (field.Value != value)
        {
            field.Value = value;
        }
    }
    
    UpdateIfChanged(langItem.Fields["Type"], updateNode.SelectSingleNode("./Type").InnerText);
