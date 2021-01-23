    interface IContainer{
      dynamic Data {get;}
    }
    
    class Container<T> : IContainer{
      T Data {get;set;}
      dynamic IContainer.Data
      {
         get { return this.Data; }
      }
    }
