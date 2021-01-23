    public class LogicProxyRouter : ILogicProxy
    {
        private readonly ILogicProxy local;
        private readonly ILogicProxy remote;
        public LogicProxyRouter(ILogicProxy local, ILogicProxy remote)
        {
            this.local = local;
            this.remote = remote;
        }
        public void Method(params)
        {
            if (someCondition)
            {
                this.local.Method(params);
            }
            else
            {
                this.remote.Method(params);
            }
        }
    }
