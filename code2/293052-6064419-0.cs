    public interface IFoo
    {
        void ImplementMe();
        int ImplementId { get; }
    }
    
    public abstract class BaseFoo : IFoo
    {
        public virtual void ImplementMe()
        {
            CommonStuff();
        }
    
        public abstract int ImplementId { get; }
    
        private void CommonStuff()
        {
            // ... do stuff ?
        }
    }
    
    public sealed class FooImplementationA : BaseFoo
    {
        public override int ImplementId { get { return 0; } }
        public override void ImplementMe()
        {
            MoreStuff();
            base.CommonStuff();
        }
    
        private void MoreStuff()
        {
            // ... do more stuff.
        }
    }
    
    public sealed class FooImplementationB : BaseFoo
    {
        public override int ImplementId { get { return 1; } }
        public override void ImplementMe()
        {
            DifferentStuff();
            base.CommonStuff();
        }
    
        private void DifferentStuff()
        {
            // ... do different stuff.
        }
    }
