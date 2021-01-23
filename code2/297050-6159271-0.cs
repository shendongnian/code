    [DataContract]
    public class MyType
    {
        public DateTime MyDTProp { get; set; }
        [DataMember(Name = "MyDTProp")]
        private string strDate
        {
            get
            {
                return this.MyDTProp.ToString("yyyy/MM/dd");
            }
            set
            {
                this.MyDTProp = DateTime.Parse(value);
            }
        }
    }
