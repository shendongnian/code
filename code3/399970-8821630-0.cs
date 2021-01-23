    public LocaleObject Locales
    {
        get { return LocalizationUtil.GetLocales(); }
    }
    <ComboBox ItemsSource="{Binding Locales, Mode=OneWay}" />
