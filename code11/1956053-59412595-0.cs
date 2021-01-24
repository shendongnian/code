    public bool IsValidDOB(DateTime date)
        {
            bool  objResult = null;
            try
            {
                if ( date < System.DateTime.Now )
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - date.Year;
                    if (date > now.AddYears(-age)) age--;
                    if (age>=18)
                    objResult =  true;
                    else
                        objResult =  false;
                }
                else
                {
                    objResult =  false;
                }
            }
            catch (Exception ex)
            {
                objResult = new  false;
                Core.Logger.AdminTrace.Logger(Core.Logger.LogArea.BusinessTier, ex);
            }
            return objResult;
        }
