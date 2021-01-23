    public interface ISomething
    {
        void Method();
    }
    public class Class1 : ISomething
    {
        public void Method()
        {
            throw new NotImplementedException();
        }
    }
    public class Class2 : ISomething
    {
        public void Method()
        {
            throw new NotImplementedException();
        }
    }
    public class Singleton
    {
        private static ISomething privateObject;
        public static ISomething Instance()
        {
            lock (privateObject)
            {
                if (privateObject == null)
                {
                    privateObject = new Class1();
                }
            }
            return privateObject;
        }
    }
    public class SingletonUsingFactory
    {
        private static ISomething privateObject;
        public static ISomething Instance(int param)
        {
            lock (privateObject)
            {
                if (privateObject == null)
                {
                    privateObject = FactoryClass.CreationObject(param);
                }
            }
            return privateObject;
        }
    }
    public static class FactoryClass
    {
        public static ISomething CreationObject(int whatToCreate)
        {
            ISomething createdObject;
            switch (whatToCreate)
            {
                case 0:
                    createdObject = new Class1();
                    break;
                case 1:
                    createdObject = new Class2();
                    break;
                default:
                    throw new Exception();
            }
            return createdObject;
        }
    }
