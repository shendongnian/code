    [DbConfigurationType(typeof(SomethingConfiguration))]
    public class SomethingDbContext : DbContext
    {
        public bool ShouldIntercept { get; set;} = false;
        //  .. DbSets, etc.
    }
