    class Brie
    {
        public override void Visit(ICheeseVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    interface ICheeseVisitor
    {
        ...
        void Visit(Brie cheese);
    }
    abstract class CheeseVisitor : ICheeseVisitor
    {
        ...
        public virtual void Visit(Brie cheese) { Default(cheese); }
        ...
    }
