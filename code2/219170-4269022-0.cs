    protected void SetParameterValue(SqlParameter parameter,object parameterValue){
    	if(IsParameterNull(parameterValue) && parameter.IsNullable){
    		parameter.Value = DBNull.Value;
    	}
    	else{
    		parameter.Value = parameterValue;
    	}
    }
    
    List<NULLTYPE> nulls = new List<NULLTYPE>(){new NULLTYPE(NULL_INT), new NULLTYPE(NULL_LONG), new NULLTYPE(null)}
    protected bool IsParameterNull(object parameterValue){
    	if(nulls.Contains(parameterValue)) return true;
    	else return false;
    }
