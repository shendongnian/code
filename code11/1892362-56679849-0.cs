    public sealed class CustomButton : Button, IDisposable
    {
        private long token;
        private TextBlock Tbk;
        public CustomButton()
        {
            this.DefaultStyleKey = typeof(CustomButton);
        }
    
        private void CallBackMethod(DependencyObject sender, DependencyProperty dp)
        {
            UpdateAttachedPropertyValue();
        }
        
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            token = this.RegisterPropertyChangedCallback(AttachedPropertyTest.Translation.TranslationModelIDProperty, CallBackMethod);
            Tbk = GetTemplateChild("TBK") as TextBlock;
            UpdateAttachedPropertyValue();        
        }
    
        public void Dispose()
        {
            this.UnregisterPropertyChangedCallback(AttachedPropertyTest.Translation.TranslationModelIDProperty,token);
        }
    
        private void UpdateAttachedPropertyValue()
        {
            AttachedPropertyTest.Translation.SetTranslationModelID(Tbk, AttachedPropertyTest.Translation.GetTranslationModelID(this));
        }
    
    }
