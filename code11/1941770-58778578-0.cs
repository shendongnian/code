    public abstract class ImportProcessor<TModel> : IImportProcessor<MaterialImportModel> where TModel: class
    {
        public void Process(IImportModel model)
        {
            Process(model as TModel);
        }
    
        public abstract void Process(TModel model);
    }
