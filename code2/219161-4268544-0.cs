    public abstract class BaseMessageObject<T>  
        where T : Entity
        {        
          public string Message { get; set; }        
 
          public BaseMessageObject<T> BuildMessage(T entity){
            if (null == entity)
              throw new ArgumentNullException(entity)
    
             BuildMessageCore (entity);
          }
          protected abstract BaseMessageObject<T> BuildMessageCore( T entity );
        }
