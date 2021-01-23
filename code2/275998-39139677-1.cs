    public ISingleResult<sp_sp_TestResult> sp_Test()
    {
    	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
    	return ((ISingleResult<sp_sp_TestResult>)(result.ReturnValue));
    }
