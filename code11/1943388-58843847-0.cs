    bool ITypeDescriptorFilterService.FilterProperties(IComponent component, IDictionary properties)
    {
        if (component == null)
            throw new ArgumentNullException("component");
        if (properties == null)
            throw new ArgumentNullException("properties");
        IDesigner designer = this.GetDesigner(component);
        if (designer is IDesignerFilter)
        {
            ((IDesignerFilter)designer).PreFilterProperties(properties);
            ((IDesignerFilter)designer).PostFilterProperties(properties);
            var propertyName = "Tag";
            var attributeArray = new Attribute[] { BrowsableAttribute.No };
            var property = properties[propertyName];
            if (property != null)
                properties[propertyName] = TypeDescriptor.CreateProperty(typeof(IDesigner),
                    (PropertyDescriptor)property, attributeArray);
        }
        return designer != null;
    }
