    public class SimpleFind<T_Adaptor, T_Item>
    {
       public T_Adaptor AdapterItem { get; set; }
       public SimpleFind(T_Adaptor item)
       {
          this.AdapterItem = item;
       }
       public bool FindMyStuff<T_Item>(T_Item value)
       {
          // Place your crazy reflection logic here...
          if (value.Property == AdapterItem.Property) return true;
          else return false;
       }
    }
