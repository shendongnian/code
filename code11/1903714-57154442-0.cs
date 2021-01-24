    public class GenericAccumulator<TAccumulator,TItem>
    {
        private readonly TAccumulator accumulator;
        private readonly IReadOnlyList<(PropertyInfo itemProperty, PropertyInfo accumulatorProperty)> propertyMap;
        public GenericAccumulator( TAccumulator accumulator )
        {
            this.accumulator = accumulator;
            PropertyInfo[] accumulatorProperties = typeof(TAccumulator).GetProperties();
            Dictionary<String,PropertyInfo> itemPropertiesByName = typeof(TItem)
                .GetProperties()
                .ToDictionary( pi => pi.Name );
            List<(PropertyInfo itemProperty, PropertyInfo accumulatorProperty)> itemProperties = new List<(PropertyInfo itemProperty, PropertyInfo accumulatorProperty)>();
            foreach( PropertyInfo accumulatorProperty in accumulatorProperties )
            {
                String expectedItemPropertyName = accumulatorProperty.Name + "InUse";
                if( itemPropertiesByName.TryGetValue( expectedItemPropertyName, out PropertyInfo itemProperty )
                {
                    itemProperties.Add( ( itemProperty, accumulatorProperty ) );
                }
            }
            this.propertyMap = itemProperties;
        }
        public GenericAccumulator<TAccumulator,TItem> Next( GenericAccumulator<TAccumulator,TItem> self, TItem item )
        {
            // Ignore `self`. It's needed for compatibility with Linq's `Func` parameter.
            foreach( PropertyInfo itemProperty in this.itemProperties )
            {
                PropertyInfo accumulatorProperty = this.propertyMap[ itemProperty ];
                Int32 itemPropertyValue        = (Int32)itemProperty.GetValue( item, null );
                Int32 accumulatorPropertyValue = (Int32)accumulatorProperty.GetValue( this.accumulator, null );
                accumulatorPropertyValue += itemPropertyValue;
                accumulatorProperty.SetValue( this.accumulator, null, accumulatorPropertyValue );
            }
        }
    }
