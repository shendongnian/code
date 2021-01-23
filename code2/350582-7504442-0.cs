    public class BarGraphData {
        public string Legend { get; set; }
        public double Value { get; set; }
    }
    
    public class BarGraphDataCollection : List<BarGraphData> {
        // add necessary constructors, if any
        
        public BarGraphData Min() {
            BarGraphData min = null;
            // finds the minmum item
            // prefers the item with the lowest index
            foreach (BarGraphData item in this) {
                if ( min == null )
                    min = item;
                else if ( item.Value < min.Value )
                    min = item;
            }
            if ( min == null )
                throw new InvalidOperationException("The list is empty.");
            return min;
        }
    
        public BarGraphData Max() {
            // similar implementation as Min
        }
    }
