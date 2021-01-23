    var a = myList.AsTruckEnumerable().FirstOrDefault();
    public static partial class Extensions
    {
      public static IEnumerable<Truck> AsTruckEnumerable (this IEnumerable<Truck> trucks)
      {
         return trucks;
      }
    }
    public class Trucks<T> : Vehicles, IEnumerable<Truck>
    {    
       public Trucks()
       {    
          // Does Compile
          var a = ((IEnumerable<Truck>)this).FirstOrDefault();
             
          // Does compile
          var b = this.AsTruckEnumerable().FirstOrDefault();
          // Doesn't Compile, Linq.FirstOrDefault not found
          //var b = this.FirstOrDefault();
       }    
 
       public new IEnumerator<Truck> GetEnumerator() { throw new NotImplementedException(); } 
    }    
