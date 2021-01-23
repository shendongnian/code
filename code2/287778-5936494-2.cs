    public class DTypeStrategy<T> where T: AbstractDType
    {
        //not sure a concrete here is a good idea, but you get the point...
        public virtual List<T> GetData()
        {
           return new List<T>();
        }
    }
    public class MyDraw : DTypeStrategy<AD2>
    {
       public override List<AD2> GetData()
       {
          return new List<AD2>();
       }
    }
