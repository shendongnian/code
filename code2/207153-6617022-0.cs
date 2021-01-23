    public class BusinessFunctionDAO : IBusinessFunctionDAO 
    {
       public BusinessFunctionDAO(IProject project)
       {
          if (project== null) new ArgumentException("project");
          _project = project;
       }
    ...
    
    
       private readonly IProject _project;
    }
