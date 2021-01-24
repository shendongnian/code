    public static Lane GetLaneWithIdentifier(int laneIdentifier = 0, string laenCode = "")
    {
    	AppContext.TraceLogger.VerboseIf(MethodBase.GetCurrentMethod().Name, traceSwitch);
    
    	try
    	{
    		using (GFC_Entities connexionEF = new GFC_Entities())
    		{
                //If laneIdentifer is not equal to 0 it will evaluate the comparison,
                //Or if laenCode is not an empty string, it will evaluate that expression
    			return connexionEF.Lanes.Where(ln => (laneIdentifier == 0 || ln.Identifier == laneIdentifier) 
                    || (laenCode == "" || ln.ShortDescription.Trim() == laenCode)).FirstOrDefault();
    		}
    	}
    	catch (EntityException ex)
    	{
    		string message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
    		throw new TechnicalException(MethodBase.GetCurrentMethod().DeclaringType.ToString(), string.Format("{0} [9001]", message), ex);
    	}
    }
