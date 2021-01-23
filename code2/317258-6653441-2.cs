    public class PrimaryKeyNamePlusId : IIdConvention 
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name+"Id");
        }
    }
