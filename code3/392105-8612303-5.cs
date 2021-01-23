    using System.Linq.Expressions;
    class MyClassFactory
    {
        HashSet<WeakReference> m_Instances = new HashSet<WeakReference>();
        MyClass Create()
        {
            var obj = new MyClass();
            m_Instances.Add(new WeakReference(obj));
            return obj;
        }
        void Execute(Expression<Action<MyClass, object>> expr, object param)
        {
            var lambda = expr.Compile();
            // Hope syntax is ok on this line
            m_Instances.RemoveWhere(new Predicate<WeakReference>(obj => !obj.IsAlive));
            foreach (var obj in m_Instances)
                lambda(obj, param);
        }
    }
