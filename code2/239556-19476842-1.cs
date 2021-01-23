        public void MakeCars()
        {
            //This wont compile as researchEngine doesn't have a public constructor and so cant be instantiated.
            CarFactory<ResearchEngine> researchLine = new CarFactory<ResearchEngine>();
            var researchEngine = researchLine.MakeEngine();
            //Can instantiate new object of class with default public constructor
            CarFactory<ProductionEngine> productionLine = new CarFactory<ProductionEngine>();
            var productionEngine = productionLine.MakeEngine();
        }
        public class ProductionEngine { }
        public class ResearchEngine
        {
            private ResearchEngine() { }
        }
        public class CarFactory<TEngine> where TEngine : class, new()
        {
            public TEngine MakeEngine()
            {
                return new TEngine();
            }
        }
