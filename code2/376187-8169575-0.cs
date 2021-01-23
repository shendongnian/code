    public class classA
    {
        private readonly object objLock = new object();
        public void MethodA(object objClassA)
        {
            classA cls = (classA)objClassA;
            cls.DoSomething();
        }
        private void DoSomething()
        {
            lock (this.objLock)
            {
                Do something with cls
            }
        }
    }
