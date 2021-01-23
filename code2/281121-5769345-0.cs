    public override object ConvertFrom 
         (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        var gridItem = context as GridItem;
      
        // If the context is indeed a property-grid item...
        if (gridItem != null)
        {
            var oldVector = (Vector3)gridItem.Value;
            ...
        }
    }
