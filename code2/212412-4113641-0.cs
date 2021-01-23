    AddElementConvention<TabControl>(TabControl.ItemsSourceProperty, "ItemsSource", "SelectionChanged")
    .ApplyBinding = (viewModelType, path, property, element, convention) => {
        if(!SetBinding(viewModelType, path, property, element, convention))
            return;
        var tabControl = (TabControl)element;
        if(tabControl.ContentTemplate == null && tabControl.ContentTemplateSelector == null && property.PropertyType.IsGenericType) {
            var itemType = property.PropertyType.GetGenericArguments().First();
            if(!itemType.IsValueType && !typeof(string).IsAssignableFrom(itemType))
                tabControl.ContentTemplate = DefaultItemTemplate;
        }
        ConfigureSelectedItem(element, Selector.SelectedItemProperty, viewModelType, path);
        if(string.IsNullOrEmpty(tabControl.DisplayMemberPath))
            ApplyHeaderTemplate(tabControl, TabControl.ItemTemplateProperty, viewModelType);
    };
