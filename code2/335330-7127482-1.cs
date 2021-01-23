        if(fooValue.IsChanged(value))
        {
        }
        static public class Ext {
          static public bool IsChanged(this Foo fooValue, Foo value) {
            return null == fooValue && null != value 
              || null != this.fooValue 
              && null == value 
              || null != this.fooValue 
              && null != value 
              && !this.fooValue.Equals(value));
           }
        }
         
