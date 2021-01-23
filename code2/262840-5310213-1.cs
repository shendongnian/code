    class ItemViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate View1Template { get; set; }
        public DataTemplate View2Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var vm = item as SampleViewModel;
            if (vm == null)
                return null;
            switch (vm.ViewType)
            {
                case ItemViewType.View1:
                    return View1Template;
                case ItemViewType.View2:
                    return View2Template;
            }
            return null;
        }
    }
