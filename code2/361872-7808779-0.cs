    				var properties = type.GetFields(BindingFlags.Static);
    
    				/*Log  properties found*/
                                /*Iam getting zero*/
    				Console.WriteLine("properties found: " +properties.Count());
    
    				foreach (var item in properties)
    				{
    					string name = item.Name;
    					string colorCode = item.GetValue(null).ToString();
    					items.Add(name, colorCode);
    				}
