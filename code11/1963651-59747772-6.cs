    public class Client
        {
            public void Execute()
            {
                var files = repository.GetFilesFromDisk();
                var fileTypeConditions = new FileConditions();
    
                foreach (var file in files)
                {
                    if (fileTypeConditions.Satisfies(file.ContentText))
                    {
                        service.SaveInDatabase(file);
                    }
                }
            }
        }
