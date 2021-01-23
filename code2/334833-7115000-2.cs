        public override object Convert(object value, SimpleConverterArguments args)
        {
            if (value == null)
                return null;
            ViewModelBase vm = value as ViewModelBase;
            if (vm != null && vm.PageTemplate != null)
                return vm.PageTemplate;
            System.Windows.Controls.UserControl template = GetTemplateFromObject(value);
            if (vm != null)
                vm.PageTemplate = template;
            if (template != null)
                template.DataContext = value;
            return template;
        }
