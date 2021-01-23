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
        ...
        this.Background = GetValueFromStyle(typeof(Button), BackgroundProperty) as Brush;
