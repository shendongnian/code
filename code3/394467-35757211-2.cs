    private string DebuggerString {
	    get {
    		StringBuilder sb = new StringBuilder();
		    sb.Append("Whatever you want your Parent class' Debugger Text To Say");
		    var properties = typeof(GroupQuote).GetProperties()
    			.Where(x =  > x.PropertyType.IsDefined(typeof(DebuggerDisplayAttribute))
					     && x.PropertyType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Any(y =  > y.Name == "DebuggerString"));
		    foreach(PropertyInfo property in properties) {
    			object itemWithProperty = property.GetValue(this);
			//we have to check our property for null, otherwise trying to get its DebuggerString property will throw an exception
            if (itemWithProperty != null) {
    				PropertyInfo privateDebuggerProperty = property.PropertyType.GetProperty("DebuggerString", BindingFlags.NonPublic | BindingFlags.Instance);
				    sb.Append(privateDebuggerProperty.GetValue(itemWithProperty)as string);
			    }
		    }
		    return sb.ToString();
	    }
    }
