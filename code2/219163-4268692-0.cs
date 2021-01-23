    [ContractClass(typeof(BaseMessageObjectContract<>))]
    public abstract class BaseMessageObject<T> where T : Entity {         
      public string Message { get; set; }         
      public abstract BaseMessageObject<T> BuildMessage(T entity); 
    }
    [ContractClassFor(typeof(BaseMessageObject<>))]
    abstract class BaseMessageObjectContract<T> : BaseMessageObject<T> where T : Entity {
      public override BaseMessageObject<T> BuildMessage(T entity) { 
        Contract.Requires<ArgumentNullException>(entity != null);
        return null;
      }
    }
