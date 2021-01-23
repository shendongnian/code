    public class ComplexAlgorithm
    {
        protected DatabaseAccessor _data;
    
        public ComplexAlgorithm(DatabaseAccessor dataAccessor)
        {
            _data = dataAccessor;
        }
    
        public int RunAlgorithm()
        {
            // RunAlgorithm needs to call methods from DatabaseAccessor
        }
    }
