    public class XYZProductValidator : IProductValidator
    {
         public bool CanProcess(string productCode)
         {
             return productCode == "XYZ";
         }
         public void Validate(string keyCode)
         {
             //validation logic
         }
    }
