        public JsonResult SaveField(int claimId, string field, string value)
        {
            try
            {
                var claim = db.Claims.Where(c => c.ClaimID == claimId).SingleOrDefault();
                if (claim != null)
                {
                    if(FieldSave(claim, field, value))
                        return Json(new DataProcessingResult { Success = true, Message = "" });
                    else
                        return Json(new DataProcessingResult { Success = false, Message = "Save Failed - Could not parse " + field });
                }
                else
                    return Json(new DataProcessingResult { Success = false, Message = "Claim not found" });
            }
            catch (Exception e)
            {
                //TODO Make this better
                return Json(new DataProcessingResult { Success = false, Message = "Save Failed" });
            }
        }
        bool FieldSave(Claim claim, string field, string value)
        {
            
            //our return value
            bool FieldWasSaved = true;
            string[] path = field.Split('.');
            var subObject = GetMethods[path[0]](this, claim);
            var secondParams = path[1];
            PropertyInfo propertyInfo = subObject.GetType().GetProperty(secondParams);
            
            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                FieldWasSaved = SetValue[Nullable.GetUnderlyingType(propertyInfo.PropertyType)](propertyInfo, subObject, value);
            }
            else
            {
                FieldWasSaved = SetValue[propertyInfo.PropertyType](propertyInfo, subObject, value);
            }
            
            db.SaveChanges();
            return FieldWasSaved;
        }
        // these are used for dynamically setting the value of the field passed in to save field
        // Add the object look up function here. 
        static Dictionary<string, Func<dynamic, dynamic, dynamic>> GetMethods = new Dictionary<string, Func<dynamic, dynamic, dynamic>>() 
        { 
            { "Loan", new Func<dynamic, dynamic, dynamic>((x, z)=> x.GetLoan(z)) },
            // and so on for the 15 or 20 model classes we have
        };
        // This converts the string value comming to the correct data type and 
        // saves the value in the object
        public delegate bool ConvertString(PropertyInfo prop, dynamic dynObj, string val);
        static Dictionary<Type, ConvertString> SetValue = new Dictionary<Type, ConvertString>()
        {
            { typeof(String), delegate(PropertyInfo prop, dynamic dynObj, string val)
                {
                    if(prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(dynObj, val, null);
                        return true;
                    }
                    return false;
                }
            },
            { typeof(Boolean), delegate(PropertyInfo prop, dynamic dynObj, string val)
                {
                    bool outBool = false;
                    if (Boolean.TryParse(val, out outBool))
                    {
                        prop.SetValue(dynObj, outBool, null);
                        return outBool;
                    }
                    return false;
                } 
            },
            { typeof(decimal), delegate(PropertyInfo prop, dynamic dynObj, string val)
                {
                    decimal outVal;
                    if (decimal.TryParse(val, out outVal))
                    {
                        prop.SetValue(dynObj, outVal, null);
                        return true;
                    }
                    return false;
                } 
            },
            { typeof(DateTime), delegate(PropertyInfo prop, dynamic dynObj, string val)
                {
                    DateTime outVal;
                    if (DateTime.TryParse(val, out outVal))
                    {
                        prop.SetValue(dynObj, outVal, null);
                        return true;
                    }
                    return false;
                } 
            },
        };
