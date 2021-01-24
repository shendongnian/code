        public interface IImportProcessorFactory 
        {
            dynamic Get(Parameter parameter);
        }
    
        public class ImportProcessorFactory : IImportProcessorFactory
        {
            public dynamic Get(Parameter parameter)
            { 
                switch (parameter)
                {
                    case Parameter.Materials:
                        return new MaterialImportProccessor() ; 
    
                    case Parameter.Companies:
                        return new CompaniesImportProccessor();
                    default:
                        return null;
                }
            }
        }
