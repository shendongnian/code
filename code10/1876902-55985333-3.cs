    public class Fruits : Aliments
    {
        public Fruits(List<Fruit> fruitList)
            : base(new List<Aliment>(fruitList.Cast<Aliment>()))
        { }
    }
