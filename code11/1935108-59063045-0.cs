    try
            {
                if (entry.Properties[propertyName].Value == null)
                {
                    if (dbValue != "")
                    {
                        //Value Null in AD, but Not Null in DB. AD value to be updated with DB value
						//Write Log
						entry.Properties[propertyName].Value = dbValue;
                        return 1;
                    }
                }
                else
                {
                    //Value Not Null in AD
                    if (!dbValue.Equals(entry.Properties[propertyName].Value))
                    {
                        // Value Not Null in AD And Not Matching With DB Value
						//Write Log
                        if (dbValue != "")
                        {
                            //Value Present in AD & DB Both, but not same. AD Value to be updated with DB Value
                            entry.Properties[propertyName].Value = dbValue;
                        }
                        else
                        {
                            //Value Present in AD but blank in DB. AD Value to be cleared.
                            entry.Properties[propertyName].Clear();
                        }
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                //Write Log
                return 0;
            }
