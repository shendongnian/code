    abstract class ABase {
        public abstract string A { get; }
    }
    
    interface IB {
        string B { get; }
    }
    
    class My : ABase, IB {
        public override string A { get; private set; }
        public virtual string B { get; private set; }
        
        public My(string a, string b) {
            A = a;
            B = b;
        }
    }
