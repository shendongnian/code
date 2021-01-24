    public class CorrectorBehaviourExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(CorrectorBehavior);
            }
        }
        protected override object CreateBehavior()
        {
            return new CorrectorBehavior();
        }
    }
