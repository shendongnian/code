    // give these structs better names if you can
    struct StringPair {
        public string Item1 { get; }
        public string Item2 { get; }
        
        public StringPair(string item1, string item2) {
            Item1 = item1;
            Item2 = item2;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
    
            if (GetType() != obj.GetType())
            {
                return false;
            }
            
            var pair = (StringPair)obj;
            return Item1 == pair.Item1 && Item2 == pair.Item2;
        }
        
        // remember to implement Equals and GetHashCode!
        public override int GetHashCode() {
            return HashCode.Combine(Item1, Item2);
        }
    
    }
    
    struct Item {
        public decimal Amount { get; }
        public decimal Price { get; }
        public long TimestampUnixEpoch { get; }
        
        public Item(decimal amount, decimal price, long timestampUnixEpoch) {
            Amount = amount;
            Price = price;
            TimestampUnixEpoch = timestampUnixEpoch;
        }
    }
