    protected string GetWithMsg(object oItem, string cField, string TheMsg)
    {
        var TheData = DataBinder.Eval(oItem, cField);
        
        if(TheData == null)
        	return TheMsg;
        else
        	return TheData.ToString();
    }
