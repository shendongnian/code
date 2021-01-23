    abstract class ABase
        abstract public A : string { get; }
    
    interface IB
        B : string { get; }
    
    [Record]
    class My : ABase, IB
        public override A : string { get; }
        public virtual  B : string { get; }
