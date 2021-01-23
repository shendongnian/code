    public class A
    {
        public object Condition
        {
            get;
            set;
        }
    }
    
    public class B: A
    {
        public void SetCondition(Tuple<int, string> condition)
        {
            base.Condition = condition;
        }
    }
