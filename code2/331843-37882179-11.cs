    public class SomeClass : ISomeClass
    {
        public SomeClass(ISomeStrategyFactory strategyFactory){
    
            IStrategy strat = strategyFactory.GetStrategy("HelloStrategy");
            strat.Execute();
        
        }
    }
