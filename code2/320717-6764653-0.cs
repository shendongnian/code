    public class MyObject
    {
        public virtual long MyId { get; set; }
        public virtual MyChild Child { get; set; }
    
        protected /*internal*/ virtual MyChild ChildForPersisting
        {
            get { return (MyChild.Id == 0) ? null : Child; }
            set { if (value != null) Child = value; }
        }
    
        public MyObject()
        {
            Child = new MyChild();
        }
    }
    
    // with internal
    References(x => x.ChildForPersisting, "ChildId")
    // without internal
    References(Reveal.Member<MyChild>("ChildForPersisting"), "ChildId")
