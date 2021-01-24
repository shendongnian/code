    public class Rule {
    
      protected Func<Data, DataType, Boolean> _isSatisfied {get; set;}
    	
      // Deafult constructor is optional. I keep it just rise a correct type of exception in case any child class call IsSatisfied without set it first.
      public Rule()
      {
    	  _isSatisfied = (data, dataType) => { throw new NotImplementedException(); }; // Or any default behavior you want.
      }
      // this contructor will provide the behavior you want.
      public Rule(Func<Data, DataType, Boolean> isSatisfied)
      {
    	  _isSatisfied = isSatisfied;
      }
    	
      // This method now is only a wrapper to our Func<>
      public virtual Boolean IsSatisfied(Data data, DataType dataType)
      {
    	  return _isSatisfied(data, dataType);
      }
    
    }
