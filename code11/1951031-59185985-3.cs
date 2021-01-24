    //Abstraction
    public interface ITaskProviderFactory {
        ITaskEnumerableProvider GetTaskProvider();
    }
    
    //Implementation
    public class DefaultTaskProviderFactory : ITaskProviderFactory{
        private readonly DBConfig config;
        
        public DefaultTaskProviderFactory(DBConfig config) {
            this.config = config;
        }
        
        public ITaskEnumerableProvider GetTaskProvider() {
            switch (config.DAL) {
                case "ADO":
                    return new ADOTaskProvider.Tasks(config.ConnectionString);
                case "EFCore":
                    return new EFCoreTaskProvider.Tasks(config.ConnectionString);
                default:
                    throw new FormatException("The format of the variable which represent the selected DAL was not correct");
            }
        }
    }
    
