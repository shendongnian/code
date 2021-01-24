    public static class SampleFunction
    {
        static SampleFunction()
        {
            ServicePointManager.UseNagleAlgorithm = false;
        }
    
        [FunctionName("SampleFunctionOperation1")]
        public static async Task<IActionResult> Operation1...
    
    }
