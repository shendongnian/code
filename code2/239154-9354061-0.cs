    public static class FixLogicalOperationStackBug
    {
        private static bool _fixed = false;
        public static void Fix()
        {
            if (!_fixed)
            {
                _fixed = true;
                Type taskType = typeof(Task);
                var s_ecCallbackField = taskType.GetFields(BindingFlags.Static | BindingFlags.NonPublic).First(f => f.Name == "s_ecCallback");
                ContextCallback s_ecCallback = (ContextCallback)s_ecCallbackField.GetValue(null);
                ContextCallback injectedCallback = new ContextCallback(obj =>
                {
                    // Next line will set the private field m_IsCorrelationMgr of LogicalCallContext which isn't cloned
                    CallContext.LogicalSetData("System.Diagnostics.Trace.CorrelationManagerSlot", Trace.CorrelationManager.LogicalOperationStack);
                    s_ecCallback(obj);
                });
                s_ecCallbackField.SetValue(null, injectedCallback);
            }
        }
    }
