    using System.Linq.Dynamic;
     
    namespace System.Linq.Dynamic
    {
      public class Example
      {
       // Assuming some value is assigned to below field somewhere... 
       private IEnumerable<Address> m_Addresses;
       public void FilterByZipCode(string zipCode)
       {
          var x = m_Addresses.AsQueryable().Where("Zip == @0", zipCode);
          dowork(x);
       }
      }
      public class Address
      {  
         public String Zip { get; set; }
         // More Properties...  
      }
    }
