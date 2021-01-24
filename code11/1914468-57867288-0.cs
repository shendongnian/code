    public class TranslateExtension : IMarkupExtension<BindingBase>
    {       
        public TranslateExtension(string text)
        {
            Text = text;            
        }
    
        public string Text { get; set; }
    
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    
        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                    Source = Translator.Instance,
            };
        return binding;
        }        
    }
