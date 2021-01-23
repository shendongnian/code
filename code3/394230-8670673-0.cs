    [XmlInclude(typeof(ProblemImplementationOne<int>))] 
    [XmlInclude(typeof(ProblemImplementationTwo<int>))] 
    public class MyClassToSerialize 
    { 
        public Problem<int> Problem; 
    } 
     
    [XmlInclude(typeof(ProblemImplementationOne<string>))] 
    [XmlInclude(typeof(ProblemImplementationTwo<string>))] 
    public class MyOtherClassToSerialize 
    { 
        public Problem<string> Problem; 
    } 
