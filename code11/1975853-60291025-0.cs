public class ItemProperties 
{
public double Price {get; set;} = 0;
public int Customers {get; set;} = 0;
//Whichever other properties you were thinking of using. 
}
static ItemProperties AddAll(Dictionary<string, ItemProperties> items)
ItemProperties finalitem = new ItemProperties(); 
{
foreach (var item in items) 
{
finalitem.Price += item.Price;
finalitem.Customers += item.Customers;
//Repeat for all other existing properties.
}
return finalitem;
}
Of course, this only works if the number and kind of properties is immutable. Another way to approach this problem would be to use TryParse to find properties in Dictionary2 that you think can be added. This is problematic however, and requires some good error checking.
static Dictionary < string, string > AddNestedDictionary(Dictionary < string, Dictionary < string, string > items) {
 Dictionary < string, string > finalitem = new Dictionary < string, string > ();
 foreach(var item in items) {
  foreach(var prop in item) {
   if (!finalitem.ContainsKey(prop.Key)) {
    finalitem.Add(prop);
   }
   double i = 0;
   if (Double.TryParse(prop.Value, out i)) {
    finalitem[prop.Key] += i;
   }
  }
 }
return finalitem;
}
Again, not the best answer compared to the simplicity of a static class. But that would be the price you pay for nonclarity.
