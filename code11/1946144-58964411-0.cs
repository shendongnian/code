    public class FruitBasket
    {
        public Fruit CurrentFruit { get; set; }
        public FruitBasket(Fruit fruit)
        {
            CurrentFruit = fruit;
        }
        public List<Fruit> GetFruits(connection)
        {
            var fruitType = CurrentFruit.GetType();
            if (fruitType == typeof(Banana))
            {
                var bananas = connection.Query<Banana>("Select * from Bananas");
                return bananas;
            }
            else if (fruitType == typeof(Orange))
            {
                var oranges = connection.Query<Orange>("Select * from Oranges");
                return oranges;
            }
        }
    }
    public class Fruit { }
    public class Orange : Fruit { }
    public class Banana : Fruit { }
