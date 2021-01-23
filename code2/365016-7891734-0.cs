    public enum Visibility
    {
        Public,
        Private
    }
    public abstract class VisibilityState
    {
        public Visibility Visibility { get; private set; }
        protected VisibilityState(Visibility visibility)
        {
            Visibility = visibility;
        }
    }
    public class PublicVisibilityState : VisibilityState
    {
        public PublicVisibilityState() : base(Visibility.Public) { }
    }
    public class PrivateVisibilityState : VisibilityState
    {
        public PrivateVisibilityState() : base(Visibility.Private) { }
        public OtherEnum OtherEnumState { get; set; }
    }
    public enum OtherEnum
    {
        Abc, Mno, Pqr
    }
