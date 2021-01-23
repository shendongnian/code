    public bool ProblematicMethod(object argument) 
    { 
      MyGenericCollection impossibleCast = argument as MyGenericCollection;
      if( impossibleCast != null )
        return impossibleCast.MyProperty; 
    
      // Other castings?
      return false;
    } 
