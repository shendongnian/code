    // "ExportFactory"
    public sealed class DataStoreProvider
    {
        [Export(typeof(Model))]
        public Model Item
        {
            get 
            {
                return [custom logic];
            }
        }
    }
    
    public class NeedsModel
    {
        [Import(typeof(Model))]
        public Model Item { get; set; }
    }
