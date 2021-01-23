    public static class CrmUtils
    {
        public static OptionSetValue OptionSetValueOrNull(int? value)
        {
            return value == null ? null : new OptionSetValue(value);
        }
        public static EntityReference EntityReferenceOrNull(Guid? id, string entityName)
        {
            return id == null ? null : new EntityReference(entityName, id);
        }
    }
