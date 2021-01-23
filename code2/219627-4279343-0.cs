    public class ActionExecuter
    {
        private MulticastDelegate del;
        public ActionExecuter(MulticastDelegate del)
        {
            this.del = del;
        }
        public object Execute(params object[] p)
        {
            return del.DynamicInvoke(p);
        }
    }
