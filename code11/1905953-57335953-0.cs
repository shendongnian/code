    public class Thing
    {
        public Thing(int number) { Number = number; }
        public int Number { get; }
    }
    public class Thingy
    {
        public Thingy(string text) { Text = text; }
        public string Text { get; }
    }
    public class ThisThing
    {
        public ThisThing(dynamic chosenThing, string nameOfTheThing)
        {
            ChosenThing = chosenThing;
            NameOfTheThing = nameOfTheThing;
        }
        // Cache the accepted types
        private static readonly ICollection<Type> AcceptedTypes = new HashSet<Type> { typeof(Thing), typeof(Thingy) };
        private dynamic _chosenThing;
        public dynamic ChosenThing
        {
            get => _chosenThing;
            private set
            {
                if (!AcceptedTypes.Contains(value.GetType()))
                {
                    throw new ArgumentException($"ChosenThing must be {string.Join(" or ", AcceptedTypes.Select(t => t.Name))}");
                }
                _chosenThing = value;
            }
        }
        public string NameOfTheThing { get; }
    }
