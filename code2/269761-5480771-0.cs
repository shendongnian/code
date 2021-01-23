    public class SingletonWidget
    {
        private static readonly Implementation SingleInstance ;
        public void DoSomething( int someValue )
        {
            SingleInstance.DoSomething( someValue ) ;
            return ;
        }
        public int SomeProperty
        {
            get
            {
                return SingleInstance.SomeProperty ;
            }
            set
            {
                SingleInstance.SomeProperty = value ;
            }
        }
        static SingletonWidget()
        {
            SingleInstance = new Implementation() ;
            return ;
        }
        private class Implementation
        {
            public void DoSomething( int someValue )
            {
                // ...
            }
            public int SomeProperty { get ; private set ; }
        }
    }
