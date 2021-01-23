    public static class SafePod
    {
        public static Func<TResult?> CreateForValueTypeResult<TResult>(Func<TResult> jobUnit) where TResult : struct
        {
            Func<TResult?> wrapperFunc = () =>
            {
                try { return jobUnit.Invoke(); } catch { return null; }
            };
            return wrapperFunc;
        }
        public static Func<TResult> CreateForReferenceTypeResult<TResult>(Func<TResult> jobUnit) where TResult : class
        {
            Func<TResult> wrapperFunc = () =>
            {
                try { return jobUnit.Invoke(); } catch { return null; }
            };
            return wrapperFunc;
        }
    }
	
