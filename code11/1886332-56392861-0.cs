    RuntimeTypeModel.Default.DynamicTypeFormatting += (sender, args) => {
    if (args.FormattedName.Contains("System.String, System.Private.CoreLib"))
    {
		args.Type = typeof(string);
    }};
