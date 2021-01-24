    class Program
    {
        static async Task Main(string[] args)
        {
            IModelService modelService = new ModelService();
            var modelsIds = await modelService.GetModelsIds();
            
            if (!modelsIds.Any())
            {
                for (int i = 0; i <= 10; i++)
                {
                    await modelService.AddModel();
                }
            }
            Task.WaitAll();
            foreach (var modelId in modelsIds)
            {
                Console.WriteLine($"ProductID: {modelId}");
            }
        }
    }
