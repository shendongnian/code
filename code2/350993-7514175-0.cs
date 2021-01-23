    public class Item {
        public string Type { get; set; }    
        public int Stock { get; set; }    
        public decimal Price { get; set; }
        public override string ToString() {
            return itemType +  "," + itemStock + "," + itemPrice;
        }
    }
