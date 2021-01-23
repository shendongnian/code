    public abstract class ChartProperties : Page
    {
        protected abstract int StartBalance {get;}
        
        public RepeatedCallParameters PrepareRepeatedCallParameters()
        {
             RepeatedCallParameters p = new RepeatedCallParamters();
             p.StartBalance = StartBalance;
             return p;  
        }
    }
