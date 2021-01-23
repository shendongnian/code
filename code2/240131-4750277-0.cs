    using System.Runtime.Serialization;
    public class PageNavigation
    {
        public string Page_Number { get; set; }
        public string Page_Count { get; set; }
    
        public PageNavigation()
        {
            Init();
        }
        [OnDeserialize]
        void Init()
        {
            Page_Number = "1";
            Page_Count = "2";
        }
    }
