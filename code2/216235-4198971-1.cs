    public class ValueFromStyleExtension : MarkupExtension
    {
        public ValueFromStyleExtension()
        {
        }
        public object StyleKey { get; set; }
        public DependencyProperty Property { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (StyleKey == null || Property == null)
                return null;
            return GetValueFromStyle(StyleKey, Property);
        }
        private static object GetValueFromStyle(object styleKey, DependencyProperty property)
        {
            Style style = Application.Current.TryFindResource(styleKey) as Style;
            while (style != null)
            {
                var setter =
                    style.Setters
                        .OfType<Setter>()
                        .FirstOrDefault(s => s.Property == property);
                if (setter != null)
                {
                    return setter.Value;
                }
                style = style.BasedOn;
            }
            return null;
        }
    }
