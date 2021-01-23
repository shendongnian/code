    public class ExternalClass
    { 
        private InternalClass m_NestedClass = new InternalClass();
    
        public InternalClass
        {
          get
          {
               return m_NestedClass;
          }
        }
    }
