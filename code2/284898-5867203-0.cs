    public static class EdmFunctions
    {
        [EdmFunction("TestModel.Store", "FunctionName")]
        public static string SomeName(string someParam)
        {
            throw new NotSupportedException("This function is only for L2E query.");
        }
    }
