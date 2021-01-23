    ConventionManager.AddElementConvention<RadTabControl>(RadTabControl.ItemsSourceProperty,
                                                      "ItemsSource",
                                                      "SelectionChanged")
	.ApplyBinding = (viewModelType, path, property, element, convention) =>
	{
		if (!ConventionManager.SetBindingWithoutBindingOrValueOverwrite(viewModelType,
		                                                                path,
		                                                                property,
		                                                                element,
		                                                                convention,
		                                                                RadTabControl.ItemsSourceProperty))
			return false;
		var tabControl = (RadTabControl) element;
		if (tabControl.ContentTemplate == null
		    && tabControl.ContentTemplateSelector == null
		    && property.PropertyType.IsGenericType)
		{
			var itemType = property.PropertyType.GetGenericArguments().First();
			if (!itemType.IsValueType && !typeof (string).IsAssignableFrom(itemType))
				tabControl.ContentTemplate = ConventionManager.DefaultItemTemplate;
		}
		ConventionManager.ConfigureSelectedItem(element,
		                                        RadTabControl.SelectedItemProperty,
		                                        viewModelType,
		                                        path);
		if (string.IsNullOrEmpty(tabControl.DisplayMemberPath))
			ConventionManager.ApplyHeaderTemplate(tabControl,
			                                      RadTabControl.ItemTemplateProperty,
			                                      RadTabControl.ItemTemplateSelectorProperty,
			                                      viewModelType);
		return true;
	};
