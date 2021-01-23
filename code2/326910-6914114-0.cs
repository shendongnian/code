    public abstract class BaseGrid {
       ... 
       ... 
       public abstract Type GetGridType();
    }
    
    public class Grid1 : BaseGrid {
    
       ...  
       ...
       public override Type GetGridType() {
          return typeof(Grid1 );
       }
    }
    
    public class Grid2 : BaseGrid {
    
       ...  
       ...
       public override Type GetGridType() {
          return typeof(Grid2 );
       }
    }
