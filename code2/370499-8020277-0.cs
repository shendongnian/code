    public class BasePageIDs {
        public virtual int Login { get { return 2; } }
        public virtual int Search { get { return 3; } }
    }
    public class SpecializedPageIDs : BasePageIds {
        public override int Search { get { return 4; } }
    }
