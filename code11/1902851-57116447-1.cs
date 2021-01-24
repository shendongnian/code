    public class baseContainer
    {
        public virtual basePropType prop { get; set; }
    }
    public class childContainer1 : baseContainer
    {
        public childProp1 childProp { get; set; }
        public override basePropType prop 
        {
            get => childProp;
            set => (childProp1)childProp
        }
    }
