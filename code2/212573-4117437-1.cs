    class Program
    {
        static void Main()
        {
            DelegateApproach();
            MethodInfoApproach();
        }
    
        static void DelegateApproach()
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
    
        static void MethodInfoApproach()
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
    
        static MethodInfo GetMethodInfo()
        {
            return typeof(Program)
                    .GetMethod("TestMethod", BindingFlags.NonPublic | BindingFlags.Static);
        }    
    
        static void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
