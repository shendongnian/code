    var oldList = new List<Item>(); // oldList
    var newList = new List<Item>(); // new list
    var distinctList = newList.Except(oldList,new ItemEqualityComparer()).ToList();
 
    class ItemEqualityComparer : IEqualityComparer<Item>
            {
                public bool Equals(Item i1, Item i2)
                {
                    if (i1.ItemID == i2.ItemID && i1.QuantitySold != i2.QuantitySold)
                        return false;
                    return true;
                }
    
                public int GetHashCode(Item item)
                {
                    return item.ItemID.GetHashCode();
                }
            }
    public class Item
            {
                public string ItemID { get; set; }
                public int QuantitySold { get; set; }
            }
