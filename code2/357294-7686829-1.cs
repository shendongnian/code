    class Base
    {
        public virtual string DisplayName { get; set; }
    }
    class Der : Base
    {
        public Der()
        {
            //  ok to ignore virtual member access here
            DisplayName = "Der";
        }
        public override sealed string DisplayName { get; set; }
    }
    class Leaf : Der
    { 
        private string _displayName;
        public Leaf()
        {
            _displayName = "default";
        }
        //override public string DisplayName
        //{
        //    get { return _displayName; }
        //    set { if (!_displayName.Equals(value)) _displayName = value; }
        //}
    }
