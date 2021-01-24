    public class DataReports : IDataReports {
        private readonly ITaskProviderFactory factory;
        
        public DataReports(ITaskProviderFactory factory) {
            this.factory = factory;
        }
        
        private ITaskEnumerableProvider getTaskProvider() {
            return factory.GetTaskProvider();
        } 
        
        public IEnumerable<SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrders> SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrders() {
            return getTaskProvider().SalesOrderMinMaxTotalDuePerTerritoryForMarketingOrders().ToList();
        }
    }
    
