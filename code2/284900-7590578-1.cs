    namespace Same.As.Edmx
    {
    	public static class EdmFunctions
    	{
    		[EdmFunction("SurveyDesignerModel.Store", "ProcessReplacements")]
	    	public static string ProcessReplacements(Guid VersionId, Guid SurveyId, string Input)
		    {
		    	throw new NotSupportedException("Direct calls are not supported.");
	    	}
	    }
    }
