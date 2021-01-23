    public class MethodLogger : IDisposable
    {
        public MethodLogger(MethodBase methodBase)
        {
            m_methodName = methodBase.DeclaringType.Name + "." + methodBase.Name;
            Console.WriteLine("{0} enter", m_methodName);
        }
        public void Dispose()
        {
            Console.WriteLine("{0} leave", m_methodName);
        }
        private string m_methodName;
    }
    class Program
    {
        void FooBar()
        {
            using (new MethodLogger(MethodBase.GetCurrentMethod()))
            {
                // Write your stuff here
            }
        }
    }
