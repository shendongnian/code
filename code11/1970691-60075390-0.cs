    public class ControllerPluginProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var basePath = AppContext.BaseDirectory;
            var pluginPath = Path.Combine(basePath, "plugins");
            foreach (var file in Directory.GetFiles(pluginPath, "*.dll")){
                var assembly = Assembly.LoadFile(file);
                var controllers = assembly.GetExportedTypes().Where(t => typeof(ControllerBase).IsAssignableFrom(t));
                foreach (var candidate in controllers)
                {
                    feature.Controllers.Add(candidate.GetTypeInfo());
                }
            }
        }
    }
