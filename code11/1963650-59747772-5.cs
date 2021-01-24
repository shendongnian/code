    public class FileConditions
    {
      private List<ISatisfyFileType> _conditions = new List<ISatisfyFileType>{ new HomeStrategy(), new OfficeStrategy() };
    
      public bool Satisfies(string fileType) =>
         _conditions.Any(condition => condition.Satisfies(fileType));
    
    }
