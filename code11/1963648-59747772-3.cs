    public class Client
        {
            public void Execute()
            {
                var files = repository.GetFilesFromDisk();
                var provider = new StragetyProvider();
    
                foreach (var file in files)
                {
                    var strategy = provider.GetStrategy(file.Type);
                    strategy?.Execute(file);
                }
            }
        }
