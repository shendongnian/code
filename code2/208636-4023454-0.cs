    public class ExternalClass
    {
        public string Name {get;set;}
        private InternalClass m_NestedClass = null;
        public InternalClass
        {
          get
          {
               if (m_NestedClass == null) m_NestedClass = new InternalClass();
               return m_NestedClass;
          }
        }
        public class InternalClass
        {
            public int SomeNumber {get;set}
        }
    }
