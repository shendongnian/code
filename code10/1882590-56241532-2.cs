    public static Lane GetLaneWithIdentifier(int laneIdentifier = 0, string laenCode = "")
    {
    	AppContext.TraceLogger.VerboseIf(MethodBase.GetCurrentMethod().Name, traceSwitch);
    
    	try
    	{
    		using (GFC_Entities connexionEF = new GFC_Entities())
    		{
    			Expression<Func<Lane>> predicate = laneIdentifier != 0 
                    ? c => c.Identifier == laneIdentifier 
                    : c => c.ShortDescription.Trim() == laenCode;
    			return connexionEF.Lanes.Where(predicate).FirstOrDefault();
    		}
    	}
    	catch (EntityException ex)
    	{
    		string message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
    		throw new TechnicalException(MethodBase.GetCurrentMethod().DeclaringType.ToString(), string.Format("{0} [9001]", message), ex);
    	}
    }
