    public class ItemsVM<T> : VMBase
    {
         public T parentElement;
         public ItemsVM (T _parentElement)
         {
             this.parentElement = _parentElement;
         }
         ...
    }
