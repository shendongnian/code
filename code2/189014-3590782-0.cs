    abstract class Cheese
    {
        public abstract void Visit(ICheeseVisitor visitor);
    }
    class Wensleydale : Cheese { ... }
    class Gouda : Cheese { ... }
    interface ICheeseVisitor
    {
        void Visit(Wensleydale cheese);
        void Visit(Gouda cheese);
    }
    abstract class CheeseVisitor : ICheeseVisitor
    {
        public virtual void Visit(Wensleydale cheese) { Default(cheese); }
        public virtual void Visit(Gouda cheese) { Default(cheese); }
        public virtual void Default(Cheese cheese) { }
    }
