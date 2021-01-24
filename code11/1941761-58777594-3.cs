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
    public interface IImportProcessor
    {
         void Process(IImportModel model);
    }
    public class MaterialImportProccessor : IImportProcessor
    {
        public void Process(IImportModel model)
        {
            var obj = (MaterialImportModel) model;
            // do some logic here
        }
    }
    public interface IImportProcessorFactory
    {
        IImportProcessor Get();
    }
    public class ImportProcessorFactory 
    {
        public IImportProcessor Get(Parameter parameter)
        {
             switch (Parameter) 
             {
                case "Materials":
                     IImportProcessor processor = new MaterialImportProccessor();
                     return processor;
                case "Companies":
                    IImportProcessor processor = new CompaniesImportProccessor();
                    return processor;
             }
        }
    }
