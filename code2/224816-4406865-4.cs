    public abstract class ChartProperties : Page
    {
        protected int StartBalance {get;}
        
        RepeatedCallParameters PrepareRepeatedCallParameters()
        {
             RepeatedCallParameters p = new RepeatedCallParamters();
             p.StartBalance = StartBalance;
             return p;  
        }
    }
