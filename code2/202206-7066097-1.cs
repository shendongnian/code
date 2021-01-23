    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Web;
    
    public static void CreateCSV<T>(List<T> list, string csvNameWithExt)
    {
    	if (list == null || list.Count == 0) return;
    
    	HttpContext.Current.Response.Clear();
    	HttpContext.Current.Response.AddHeader(
    		"content-disposition", string.Format("attachment; filename={0}", csvNameWithExt));
    	HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
    
    	//get type from 0th member
    	Type t = list[0].GetType();
    	string newLine = Environment.NewLine;
    
    	using (StringWriter sw = new StringWriter())
    	{
    		//gets all properties
    		PropertyInfo[] props = t.GetProperties();
    
    		//this is the header row
    		//foreach of the properties in class above, write out properties
    		foreach (PropertyInfo pi in props)
    		{
    			sw.Write(pi.Name.ToUpper() + ",");
    		}
    		sw.Write(newLine);
    
    		//this acts as datarow
    		foreach (T item in list)
    		{
    			//this acts as datacolumn
    			foreach (PropertyInfo Column in props)
    			{
    				//this is the row+col intersection (the value)
    				string value = item.GetType().GetProperty(Column.Name).GetValue(item, null).ToString();
    				if (value.Contains(","))
    				{
    					value = "\"" + value + "\"";
    				}
    				sw.Write(value + ",");
    			}
    			sw.Write(newLine);
    		}
    
    		//  render the htmlwriter into the response
    		HttpContext.Current.Response.Write(sw.ToString());
    		HttpContext.Current.Response.End();
    	}
    }
