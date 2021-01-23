    using System.Linq.Expressions;
    class MyClassFactory
    {
        LinkedList<MyClass> m_Instances = new LinkedList<MyClass>();
        MyClass Create()
        {
            m_Instances.AddLast(new MyClass());
            return m_Instances.Last.Value;
        }
        void Destroy(MyClass obj)
        {
            m_Instances.Remove(obj);
        }
        void Execute(Expression<Action<MyClass, object>> expr, object param)
        {
            var lambda = expr.Compile();
            foreach (var obj in m_Instances)
                lambda(obj, param);
        }
    }
