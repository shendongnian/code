    public class VariableColumnConverter : ITypeConverter<ApiResponse, List<AssetPrice>>
    {
        public List<AssetPrice> Convert(ApiResponse source, List<AssetPrice> destination, ResolutionContext context)
        {
            var properties = typeof(AssetPrice).GetProperties();
            destination = new List<AssetPrice>();
            foreach (var dataItem in source.data)
            {
                var price = new AssetPrice();
                foreach (var column in source.columnNames.Select((value, i) => (value, i)))
                {
                    var property = properties.SingleOrDefault(p => p.Name.Equals(column.value, StringComparison.InvariantCultureIgnoreCase));
                    if (property != null)
                    {
                        property.SetValue(price, System.Convert.ChangeType(dataItem[column.i], property.PropertyType));
                    }
                }
                destination.Add(price);
            }
            return destination;
        }
    }
