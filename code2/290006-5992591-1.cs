    public static class EdmFunctions
    {
        // First parameter is namespace of SSDL (open EDMX as XML if you are not sure about namespace)
        [EdmFunction("TestModel.Store", "udf_GetAccountTypeDescription")]
        public static string GetAccountTypeDescription(string parameter)
        {
            throw new NotSupportedException("This function is only for L2E query.");
        }
    }
