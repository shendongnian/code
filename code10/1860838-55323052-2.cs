    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration() : base()
        {
            var path = Path.GetDirectoryName(this.GetType().Assembly.Location);
            SetModelStore(new DefaultDbModelStore(path));
            SetManifestTokenResolver(new CustomManifestTokenResolver());
        }
    }
