    public static bool CheckMandatoryFields(Dictionary<string,string > mandatoryFields, object o,out StringBuilder  message)
    {
        message = new StringBuilder();
        if(mandatoryFields == null || mandatoryFields.Count == 0)
        {
            return true;
        }
        var sourceType = o.GetType();
        foreach (var mandatoryField in mandatoryFields) {
            var property = sourceType.GetProperty(mandatoryField.Key, BindingFlags.Public | BindingFlags.Static);
            if (property == null) {
                continue;
            }
            
            if (string.IsNullOrEmpty(property.GetValue(o, null).ToString()))
            {
                message.AppendLine(string.Format("{0} name is blank.", mandatoryField.Value));
            }
        }
        return message.ToString().Trim().Length == 0;
    }
