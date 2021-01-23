     public class DynamicInvocation
    {
        public event EventHandler SomeEvent;
        public void DoWork()
        {
            //Do your actual code here
            //...
            //...
            //fire event here
            FireEvent();
        }
        private void FireEvent()
        {
            var cache = SomeEvent;
            if(cache!=null)
            {
                Delegate[] invocationList = cache.GetInvocationList();
                foreach (Delegate @delegate in invocationList)
                {
                    try
                    {
                        @delegate.DynamicInvoke(null);
                    }
                    catch
                    {
                        
                    }
                }
            }
        }
    }
