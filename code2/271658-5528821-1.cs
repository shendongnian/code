    internal override object ConvertProposedValue(object value)
    {
        ...
        Type sourcePropertyType = this.Worker.SourcePropertyType;
        IValueConverter dynamicConverter = null;
        CultureInfo culture = base.GetCulture();
        if (this.Converter != null)
        {
            if (!base.UseDefaultValueConverter)
            {
                value = this.Converter.ConvertBack(value, sourcePropertyType, this.ParentBinding.ConverterParameter, culture);
                if (((value != Binding.DoNothing) && (value != DependencyProperty.UnsetValue)) && !this.IsValidValueForUpdate(value, sourcePropertyType))
                {
                    dynamicConverter = this.DynamicConverter;
                }
            }
