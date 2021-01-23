    public class Creature
    {
        public virtual void DoSomethingToCreature()
        {
            // whatever you had in your original foreach loop
        }
    }
    public class Magical : Creature
    {
        public override void DoSomethingToCreature()
        {
            base.DoSomethingToCreature();
            // ... any special processing for Magical creatures goes here...
        }
    }
