    public class MyRepositotyProvider : Provider<IMyRepositoty> {
        public static IMyRepositoty CreateInstance(string path) {
            return new MyRepository(path);
        }
    
        protected override IMyRepositoty CreateInstance(IContext context) {
            ISomeSetting setting = context.Kernel.Get<ISomeSetting>()
            var path = setting.Path;
            return CreateInstance(path);
        }
    }
