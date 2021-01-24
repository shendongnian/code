    public interface IImportModel
    {
         
    }
    public class MaterialImportModel: IImportModel
    {
        public string Name { get; set; }
    }
    public class CompanieImportModel: IImportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IImportProcessor<TModel> where TModel: IImportModel
    {
         void Process(TModel model);
    }
    public class ImportProccessor<TModel> : IImportProcessor<TModel>  where TModel: IImportModel
    {
        public void Process(TModel model)
        {
            // do some logic here
        }
    }
    public interface IImportProcessorFactory
    {
        IImportProcessor<TModel> Get<TModel>() where TModel: IImportModel;
    }
    public class ImportProcessorFactory 
    {
        public IImportProcessor<TModel> Get<TModel>() where TModel: IImportModel
        {
            IImportProcessor<TModel> processor = new ImportProccessor<TModel>();
            return processor;
        }
    }
