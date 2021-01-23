        public class CustomGroupBoxDesigner : ControlDesigner
        {
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                var c = component as CustomGroupBox;
                EnableDesignMode(c.FLP, "FLP");
            }
        }
