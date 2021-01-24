    public class TableDWG
    {
        public int Key { get; set; }
    
        public string Name { get; set; }
    
        public int Quantity { get; set; }
    
        public string Part { get; set; }
    
        public string Drawing { get; set; }
    
        public TableDWG() { }
    
        public TableDWG(int key, string name, int quatity, string part, string drawing)
        {
            Key = key;
            Name = name;
            Quantity = quatity;
            Part = part;
            Drawing = drawing;
        }
    
    }
