        public void CarFactory()
        {
            //This wont compile as researchEngine doesn't have a public constructor and so cant be instantiated.
            Car<ResearchEngine> researchCar = new Car<ResearchEngine>();
            researchCar.MakeEngine();
            //Valid use of generic 
            Car<ProductionEngine> productionCar = new Car<ProductionEngine>();
            car.MakeEngine();
        }
        public class ProductionEngine { }
        public class ResearchEngine
        {
            private ResearchEngine() { }
        }
        public class Car<TEngine> where TEngine : class, new()
        {
            public TEngine MakeEngine()
            {
                return new TEngine();
            }
        }
