    namespace ANamespace
    {
        public static class AEventHandler
        {
            internal static event Action OnInvokeA;
    
            public static void InvokeAEvent()
            {
                if(OnInvokeA != null) OnInvokeA.Invoke();
            }
        }
    }
