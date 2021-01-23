        public partial class BrickHouseFitnessContext : DbContext
    {
        public BrickHouseFitnessContext(): base(EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(ConfigurationManager.ConnectionStrings["BrickHouseFitnessContext"].ConnectionString, "EFTracingProvider"), true)
        {
        }
