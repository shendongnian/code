    class Project : IProject<Data> 
    {
        public DataD { get; }
        public void SomeSpecificMethodReferencingData()
        { 
            D.SomeSpecificMethod();  // D is of type Data
        }
    }
    
    class OtherProject : IProject<OtherData> {
        public OtherData D { get; }
        public void SomeOSpecificMethodReferencingOtherData()
        {
             D.SomeOtherSpecificMethod(14.0f); // D is of type OtherData
        }
    }
