    internal class Program
    {
        private static void Main(string[] args)
        {
            var items = new[] {
                new Item {Price = 1},
                new Item {Price = 2}
                                };
            var vendor = new Vendor {Items = items};
    
            var vendorSum = GetVendorItemsSum(vendor, x => x.Price);
        }
    
        private static int GetVendorItemsSum(Vendor vendor, Func<Item, int> func)
        {
            return vendor.Items.Sum(func);
        }
    }
    
    public class Vendor
    {
        public IEnumerable<Item> Items;
    }
    
    public class Item
    {
        public int Price { get; set; }
    }
