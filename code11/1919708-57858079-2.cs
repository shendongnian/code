    abstract class ServiceBase
    {
        public bool ServiceMethod()
        {
            if (!CheckMethod())
            {
                return false;
            }
            return ServiceMethodImpl();
        }
        protected abstract bool ServiceMethodImpl();
        private bool CheckMethod()
        {
            // ...
        }
    }
