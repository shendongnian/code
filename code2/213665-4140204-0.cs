    public class MoreDerivedType : BaseType<MoreDerivedEvent>
    {
        public override void Handle(MoreDerivedEvent handle)
        {
            base.Handle(handle);
        }
    }
