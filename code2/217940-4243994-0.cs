    public abstract class Base
    {
        public abstract List<int> List { get; }
    }
    
    public class Derived : Base
    {
        #region Overrides of Base
    
        public override List<int> List
        {
            get { return new List<int> {1, 2, 3}; }
        }
    
        #endregion
    }
