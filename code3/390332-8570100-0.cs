    private static void ShowMeAll<TClass>(IEnumerable<TClass> items, string property)
    {
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TClass));
        PropertyDescriptor targetProperty = properties.Find(property, true);
        
        if (targetProperty == null)
        {
            // Your own error handling
        }
        IEnumerable<TClass> sortedItems = items.OrderBy( a => targetProperty.GetValue(a));
        
        // Your own code to display your sortedItems
    }
