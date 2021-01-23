    public class IndexOneToManyColumnsConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            var mappingfield = instance.Key.Columns.First().GetType()
                .GetField("mapping", BindingFlags.Instance | BindingFlags.NonPublic);
            var columnMapping = (ColumnMapping)mappingfield.GetValue(instance.Key.Columns.First());
            if (!columnMapping.HasValue(c => c.Index))
            {
                var typename = instance.Member.DeclaringType.Name;
                columnMapping.Index = string.Format("index_{0}_{1}",
                    typename.ToLower(), instance.Member.Name.ToLower());
            }
        }
    }
