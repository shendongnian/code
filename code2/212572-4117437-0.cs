    class Program
    {
        static void Main()
        {
            DelegateApproach();
            MethodInfoApproach();
        }
    
        private static void DelegateApproach()
        {
            try
            {
                Action action = (Action)Delegate.CreateDelegate
                                       (typeof(Action), GetMethodInfo());
                action();
            }
            catch (NotImplementedException nie)
            {
    
            }
         }
    
        private static void MethodInfoApproach()
        {
            try
            {
                GetMethodInfo().Invoke(null, new object[0]);
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException is NotImplementedException)
                {
    
    
                }
            }
        }
    
        private static MethodInfo GetMethodInfo()
        {
            return typeof(Program)
                    .GetMethod("TestMethod", BindingFlags.NonPublic | BindingFlags.Static);
        }    
    
        private static void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
