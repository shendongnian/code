public class ProductInfo 
{
   public string Size { get; set; }
   public decimal Price { get; set; }
}
public static List<ProductInfo> GetDetails()
{
 ...
}
As for the matter of combining your lists, the Linq Zip operation is what you need.
Check the code here: https://dotnetfiddle.net/qyryvY
