    public class EntityMap : ClassMapping<Entity>
    {
        public EntityMap()
        {
            Table("Entity");
            Filter("filterName", m => m.Condition("FilteredField = :filterParamName"));
            // remaining mapping
        }
    }
