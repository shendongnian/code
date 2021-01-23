    bool IncludePropertyInFactoryMethod(StructuralType factoryType, EdmProperty edmProperty)
    {
        if (edmProperty.Nullable)
        {
            return false;
        }
    
        if (edmProperty.DefaultValue != null)
        {
            return false;
        }
    
        if ((Accessibility.ForReadOnlyProperty(edmProperty) != "public" && Accessibility.ForWriteOnlyProperty(edmProperty) != "public") ||
            (factoryType != edmProperty.DeclaringType && Accessibility.ForWriteOnlyProperty(edmProperty) == "private")
           )
        {
            //  There is no public part to the property.
            return false;
        }
    
        /*********
         * This was added:
         */
    
        var identity = edmProperty.TypeUsage.Facets
            .Where(f => f.Name == "StoreGeneratedPattern").FirstOrDefault();
     
        if (identity != null && identity.Value.ToString() == "Identity")
        {
            // property is "Identity" generated, so skip from the factory method.
            return false;
        }
    
        /*********
         * end of the custom code
         */
    
        return true;
    }
