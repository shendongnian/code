    public class A
    {
        virtual protected string name { get; set; }
    }
    public interface IInterceptor
    {
        object Invoke(MethodInfo method, params object[] arguments);
    }
    public sealed class AProxy : A
    {
        static private readonly MethodInfo getname = typeof(A).GetProperty("name", ...).GetGetMethod(true);
        static private readonly MethodInfo setname = typeof(A).GetProperty("name", ...).GetSetMethod(true);
        private readonly IInterceptor interceptor;
        public AProxy(IInterceptor interceptor)
        {
            this.interceptor = interceptor;
        }
        override protected string name
        {
            get { return this.interceptor.Invoke(AProxy.getname); }
            set { this.interceptor.Invoke(AProxy.setname, value); }
        }
    }
