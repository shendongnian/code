     public static void AddObjects(object oFrom, object oTo)
            {
                if (oFrom != null && oTo != null)
                {
                    foreach (System.Reflection.PropertyInfo f in oFrom.GetType().GetProperties())
                    {
                        if ((oTo).GetType().GetProperty(f.Name) != null)
                        {
                            try
                            {
                                string sType = f.GetType().ToString().ToLower();
                                if (sType==("int") )
                                {                              
                                    oFrom.GetType().GetProperty(f.Name).SetValue(oFrom, (int)(f.GetValue(oFrom)) + (int)(f.GetValue(oTo)));
                                }
                                if (sType=="int32" )
                                {
                                    oFrom.GetType().GetProperty(f.Name).SetValue(oFrom, (Int32)(f.GetValue(oFrom)) + (Int32)(f.GetValue(oTo)));
                                }
                                if (sType==("int64") )
                                {
                                    oFrom.GetType().GetProperty(f.Name).SetValue(oFrom, (Int64)(f.GetValue(oFrom)) + (Int64)(f.GetValue(oTo)));
                                }
    
                                // keep adding for all numeirc types.  maybe theres a better way?
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                }
            }
