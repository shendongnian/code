    public class MyPage : Page
    {
        public bool Validated { get; private set; }
    
        public override void Validate(string validationGroup)
        {
            this.Validated = true;
            base.Validate(validationGroup);
        }
    
        public override void Validate()
        {
            this.Validated = true;
            base.Validate();
        }
    }
