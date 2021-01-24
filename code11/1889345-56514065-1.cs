    public class FrenchCuisine : IFood
    {
        public string GetFood()
        {
            return "Soupe à l'oignon";
        }
    }
    public class ComidaBrasileira : IFood
    {
        public string GetFood()
        {
            return "Feijoada";
        }
    }
    public class FrenchTranslator : ITranslate
    {
        private readonly IFood food;
        public FrenchTranslator(IFood food)
        {
            this.food = food;
        }
        public string GetMenu()
        {
            return this.food.GetFood();
        }
    }
    public class PortugueseTranslator : ITranslate
    {
         private readonly IFood food;
        public PortugueseTranslator(IFood food)
        {
            this.food = food;
        }
        public string GetMenu()
        {
            return this.food.GetFood();
        }
    }
