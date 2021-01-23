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
    }
