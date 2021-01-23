    public class SomeClass
    {
        private object _lockObj = new object();
        private SomeReferenceType _someProperty;
        public SomeReferenceType SomeProperty
        {
            get
            {
                if(_someProperty== null)
                {
                    lock(_lockObj)
                    {
                        if(_someProperty== null)
                        {
                            _someProperty= new SomeReferenceType();
                        }
                    }
                }
                return _someProperty;
            }
            set { _someProperty = value; }
        }
    }
