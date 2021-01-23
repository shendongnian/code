    abstract class FruitAssociation<TAssoc, TFruit>
        where TAssoc : FruitAssociation<TAssoc, TFruit>, new()
        where TFruit : Fruit
    {
        public static readonly TAssoc Color = Define("Color");
        public static readonly TAssoc Manufacturers = Define("Manufacturers");
        protected static TAssoc Define(string name)
        {
            return new TAssoc { Name = name };
        }
        public string Name
        {
            get;
            private set;
        }
    }
    sealed class OrangeAssociation : FruitAssociation<OrangeAssociation, Orange>
    {
        public static readonly OrangeAssociation OrangeFamilies =
            Define("OrangeFamilies");
    }
