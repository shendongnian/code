    public class MyLinkButton : LinkButton
    {
        //you can then override any method/property (intellisense will guide you)
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }
    }
