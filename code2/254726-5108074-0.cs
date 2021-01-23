    public class GraphingResults : IList<GraphingResult>
    {
        private List<GraphingResult> ToolkitResultList { get; set; }
    
        public GraphingResults()
        {
            this.ToolkitResultList = new List<GraphingResult>();
        }
    
        // bunch of other stuff
    
        public int Count
        {
            get { return this.ToolkitResultList.Count; }
        }
    
    }
