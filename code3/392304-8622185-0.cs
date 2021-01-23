    [Serializable]
    public class RetryAttribute : MethodInterceptionAspect
    {
        private readonly int _times;
        public RetryAttribute(int times)
        {
            _times = times;
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            for (var left = _times; left > 0; left--)
            {
                try
                {
                    args.Proceed();
                    break;
                }
                catch (Exception)
                {
                }
            }
            args.Proceed(); // optional
        }
    }
