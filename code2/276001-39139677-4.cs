    [global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_Test")]
    public ISingleResult<sp_TestResult> sp_Test([global::System.Data.Linq.Mapping.ParameterAttribute(Name="optionalParam", DbType="Int")] System.Nullable<int> optionalParam)
    {
    	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), optionalParam);
    	return ((ISingleResult<sp_TestResult>)(result.ReturnValue));
    }
