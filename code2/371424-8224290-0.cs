    public class DataModelBuilder
    {  
      string _modelName; 
      IDataModel _dataModel; 
    
      public DataModelBuilder WithModelName(string modelName)
      {
        _modelName = modelName; 
        return this; 
      }
    
      public IDataModel Build()
      {
        _dataModel = new DataModel(); 
        _datamodel.Load(_modelName); 
        return _dataModel; 
      }
    
    }
