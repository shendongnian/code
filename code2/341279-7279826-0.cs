    public static class ObjectPersistanceExtensions{
    
           public static SaveObejct<T>(this IBaseEntity obj){
    	      
    			IObjectDal<T> _dal = AvailableSerices.Obtain<IObjectDal<T>>();
    			_dal.AddObject(obj);
    			_dal.Commit();
    	   }
    }
