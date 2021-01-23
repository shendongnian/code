    public class SettingsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GeneralSettingsTemplate { get; set; }
        public DataTemplate AdvancedSettingsTemplate { get; set; }
        public override DataTemplate SelectTemplate(Object item,
            DependencyObject container)
        {
            var vm = item as SettingsViewModel;
            if (vm == null) return base.SelectTemplate(item, container);
            if (vm.IsAdvanced)
            {
                return AdvancedSettingsTemplate;
            }
            return GeneralSettingsTemplate;
        }
    }
