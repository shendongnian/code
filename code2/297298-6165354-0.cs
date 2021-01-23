    interface ICreature
    {
        bool IsAwesome { get; set; }
        int GetScalar();
    }
    abstract class Creature : ICreature
    {
        public bool IsAwesome { get; set; }
        public virtual int GetScalar()
        {
            return 160;
        }
    }
    class SpecialCreature : Creature
    {
        public override int GetScalar()
        {
            return this.IsAwesome ? 700 : 500;
        }
    }
    class NotSoNormalCreature : Creature
    {
        public override int GetScalar()
        {
            return this.IsAwesome ? 450 : 280;
        }
    }
    // more ICreatures...
