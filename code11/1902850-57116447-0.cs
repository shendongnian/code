    public class baseContainer
    {
        public basePropType prop { get; set; }
    }
    public class childContainer1 : baseContainer
    {
        public new childProp1 prop 
        {
            get => (childProp1)base.prop;
            set => base.prop = value;
        }
    }
