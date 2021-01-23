    class Component {
        List<Component> children;
        Component parent;
        decimal _unitCost;
        public void addComponent(Component c) { children.add(c); UnitCost += c.UnitCost; } 
        
        public decimal UnitCost { 
           get {return unitCost;} 
           set { 
             if (parent != null) { 
                //update the parent cost, which will in turn update its parent etc.
                parent._unitCost -= UnitCost; parent.UnitCost += value; 
             }
             unitCost = value; 
           }
    }
