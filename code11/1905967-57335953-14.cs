    public class ThisThing
    {
        public ThisThing(IThing chosenThing, string nameOfTheThing)
        {
            ChosenThing = chosenThing;
            NameOfTheThing = nameOfTheThing;
        }
        public IThing ChosenThing { get; }
        public string NameOfTheThing { get; }
    }
