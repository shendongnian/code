    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PreApplicationStartCode
    {
        private static bool startWasCalled;
        public static void Start()
        {
            if (startWasCalled)
            {
                return;
            }
            startWasCalled = true;
            DynamicModuleUtility.RegisterModule(typeof(YourModule));
        }
    }
