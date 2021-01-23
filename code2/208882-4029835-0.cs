    [ServiceContract]
    public interface IExample
    {
        [OperationContract]
        void DoSomething(Job);
    }
    
    [DataContract]
    public class Job 
    {
        public Job(...)
        {
        }
    
        [DataMember]
    
        public string Example
        {
            get { return m_example; }
            set { m_example = value; }
        }
    }
    
    public class Example : IExample
    {
        public void DoSomething(Job job)
        {
            ...
        }
    }
