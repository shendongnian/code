    public class Parent {
    
      private List<ParentDetail> _ParentDetails = new List<ParentDetail>();
      public IList<ParentDetail> ParentDetails {
        get { return _ParentDetails; }
      }
    
      // constructor:
      public Parent() {
        this._ParentDetails = new List<ParentDetail>();
      } // constructor
    
      public IList<ParentDetail> customSort() {
        Result = new List<ParentDetail>();
        
        // use sort code here,
        // copying item references to result list
        ...   
    
        return Result;
      } 
    } // class
