    public static void FormatColumns<T>(ExcelWorksheet sheet)
    {
    	var properties = typeof(T).GetProperties();
    	foreach (var property in properties)
    	{
    		var columnIndex = Array.IndexOf(properties, property) + 1; //Since it is not zero based
    		var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType; // Checks if it's a nullable
    		var typeCode = Type.GetTypeCode(type);
    		FormatRange(sheet.Column(columnIndex), typeCode);
    	}
    }
    public static void FormatRange(ExcelColumn range, TypeCode typeCode)
    {
    	switch (typeCode)
    	{
    		case TypeCode.Int32:
    			range.Style.Numberformat.Format = "General";
    			break;
    		case TypeCode.Double:
    			range.Style.Numberformat.Format = "_(* #,##0.00_);_(* (#,##0.00);_(* \" - \"??_);_(@_)";
    			break;
    		case TypeCode.Decimal:
    			range.Style.Numberformat.Format = "_ * #,##0.00_ ;[red]_ * -#,##0.00_ ;_ * \"-\"??_ ;_ @_ ";
    			break;
    		case TypeCode.DateTime:
    			range.Style.Numberformat.Format = "dd-MMM-yy";
    			break;
    		default:
    			range.Style.Numberformat.Format = "General";
    			break;
    	}
    }
