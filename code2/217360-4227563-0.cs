    public class Data
    {
        public string Comment { get; set; }
        public List<double> TraceData { get; set; }
        public Data DeepCopy()
        {
            return new Data
            {
                Comment = this.Comment, 
                TraceData = this.TraceData != null
                    ? new List<double>(this.TraceData)
                    : null;
            }
        }
    }
