        [Function("dbo.GetMultipleSets"]
        [ResultType(typeof(Type_1))]
        [ResultType(typeof(Type_2))]
        public IMultipleResults GetMultipleSets()
        {
            IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()));
            IMultipleResults results  = (IMultipleResults)result.ReturnValue;
            return results;
        }
