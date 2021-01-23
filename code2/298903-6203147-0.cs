    public class BaseEntityPropertiesConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.EntityType.IsSubclassOf(typeof(BaseEntity)))
            {
                switch instance.Name
                {
                    case "CreatedDate":
                        instance.Not.Nullable().Not.Update();
                        break;
                    case "CreatedBy":
                        instance.Not.Nullable().Length(100);
                        break;
                    //etc...
                }
            }
        }
    }
