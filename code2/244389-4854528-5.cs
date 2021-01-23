    public partial class Creature   // rest of your class is omitted in this example
    {
        public virtual void TakeHit()
        {
            // whatever you had in your original foreach loop, e.g.:
            HealthPoints--;
        }
    }
    public partial class Magical : Creature
    {
        public override void TakeHit()
        {
            // ... any special processing for Magical creatures goes here, e.g.:
            Mana--;
            // (you could also call 'base.TakeHit()' in this method.)
        }
    }
