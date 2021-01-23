    public class CustomMappingManager : IReadOnlyMappingManager
    {
    public ICollection<SolrFieldModel> GetFields(Type type)
        {
            IEnumerable<KeyValuePair<PropertyInfo, IndexFieldAttribute[]>> mappedProperties = this.GetPropertiesWithAttribute<IndexFieldAttribute>(type);
            IEnumerable<SolrFieldModel> fields = from mapping in mappedProperties
                                                 select new SolrFieldModel()
                                                 {
                                                     Property = mapping.Key,
                                                     FieldName = mapping.Value[0].FieldName ?? mapping.Key.Name
                                                 };
            return new List<SolrFieldModel>(fields);
        }
    public SolrFieldModel GetUniqueKey(Type type)
        {
            SolrFieldModel uniqueKey;
            IEnumerable<KeyValuePair<PropertyInfo, IndexUniqueKeyAttribute[]>> mappedProperties = this.GetPropertiesWithAttribute<IndexUniqueKeyAttribute>(type);
            IEnumerable<SolrFieldModel> fields = from mapping in mappedProperties
                                                 select new SolrFieldModel()
                                                 {
                                                     Property = mapping.Key,
                                                     FieldName = mapping.Value[0].FieldName ?? mapping.Key.Name
                                                 };
            uniqueKey = fields.FirstOrDefault();
            if (uniqueKey == null)
            {
                throw new Exception("Index document has no unique key attribute");
            }
            return uniqueKey;
        }
    }
