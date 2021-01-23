    [DataContract]
    public class MyContract
    {
        private ObservableCollection<string> list;
    
        internal MyContract()
        {
            List = new ObservableCollection<string>();
        }
    
        [DataMember]
        public ObservableCollection<string> List
        {
            get
            {
                return list;
            }
            private set
            {
                list = value;
                list.CollectionChanged += 
                   (s, e) => 
                       Console.WriteLine("It is never happens!! Why? - Are you sure?!");
            }
        }
    }
