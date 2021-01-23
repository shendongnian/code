    [DataContract]
    public class ClassToSerialize
    {
        [NonSerialized] 
        private bool _mf;
        public bool IsMf
        {
            get { return _mf; }
            set{ _mf = value;}  
        }
    
        [DataMember]
        public char PrimaryExc { get; set; }        
    }
    
    class Program
    {
        static void Main()
        {
            var obj = new ClassToSerialize 
            {
                PrimaryExc = 'a', 
                IsMf = false
            };
            var serializer = new DataContractJsonSerializer(obj.GetType());
            serializer.WriteObject(Console.OpenStandardOutput(), obj);
        }
    }
