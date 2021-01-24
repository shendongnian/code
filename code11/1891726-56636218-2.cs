	public static T Map<T>(OEDData OED, out string Errors)
	{
	    string mappingErrors = string.Empty;
	
	    object retObj = Activator.CreateInstance(typeof(T)); //we'll reset this later if we need to, e.g. targeting a member
	
	    foreach (PropertyInfo pi in typeof(T).GetProperties()) 
	    {
	        if (pi.GetCustomAttribute(typeof(OEDPropertyAttribute)) is OEDPropertyAttribute propAtt) 
	        {
	            PropertyInfo piTargetMember = null;
	
	            if (!string.IsNullOrEmpty(propAtt.TargetMember)) 
	            {
	                try 
	                { 
	                    piTargetMember = pi.PropertyType.GetProperty(propAtt.TargetMember); 
	                }
	                catch (Exception ex) 
	                { 
	                    mappingErrors += $"Error locating target member \"{propAtt.TargetMember}\" for type \"{propAtt.GetType().Name}\" when setting field \"{propAtt.Field.ToLower()}\"." + 
										 $"\r\nMake sure the target member name is spelled correctly. Target member names ARE case sensitive.\r\nError: {ex.Message}\r\n"; 
	                }
	            }
	
	            if (propAtt.IsHeaderField) //header fields
	            {
	                /*snip*/
	            } 
	            else //fields
	            {
	                try 
	                {
	                    var fVal = OED.Fields.FirstOrDefault((f) => string.Equals(f.FieldName, propAtt.Field, StringComparison.CurrentCultureIgnoreCase))?.Value;
						
	                    if (piTargetMember == null)
						{
							pi.SetValue(retObj, ChangeType(fVal, pi.PropertyType));
						}
						else
						{
							object propInstance = pi.GetValue(retObj);
							if (propInstance == null)
							{
								// construct the value which is the property pointed to by 'pi'
								propInstance = Activator.CreateInstance(pi.PropertyType);
								pi.SetValue(retObj, propInstance);
							}
		                    piTargetMember.SetValue(propInstance, ChangeType(fVal, piTargetMember.PropertyType));
						}
	                }
	                catch (Exception ex) 
	                { 
	                    mappingErrors += $"Unable to map oed field value: \"{propAtt.Field.ToLower()}\".\r\nError: {ex.Message}\r\n";
	                }
	            }
	        }
	    }
	
	    Errors = mappingErrors;
	
	    return (T) retObj;
	}
