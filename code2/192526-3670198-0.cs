    // The code in this CS file is auto-generated.
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;
    
    namespace WpfApplication
    {
    
    <#
    	string[] classes = new string[]
            {"CourtEventCode", "SomeOtherCode", "WhatElseIsThere"};
    
    	foreach (string classname in classes)
    	{
    #>
    	public class <#= classname #>ValueConverter : IValueConverter
    	{
    		object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    		{
    			Dictionary<int, string> codes = CacheManager.CodeLookup< <#= classname #> >();
    			int id = 0;
    			string result = string.Empty;
    
    			if (int.TryParse(value.ToString(), out id) && id > 0)
    			{
    				if (codes.ContainsKey(id))
    				{
    					result = codes[id];
    				}
    				else
    				{
    					result = "Unknown";
    				}
    			}
    
    			return result;
    		}
    
    		// Implement the rest of IValueConverter
    	}
    
    <# } #>
    }
