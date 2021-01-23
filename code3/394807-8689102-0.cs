    public class Temp // safe, not unsafe
    {
        public class Node // class, not struct
        {
            public Node Left { get; set; } // properties, not fields
            public Node Right { get; set; } 
            public int Value { get; set; }
        }
    
        public Temp()
        {
            Node node = new Node();
            node.Left = null; // member access dots, not pointer-access arrows
            node.Right = null;
            node.Value = 10;
        }
    }
    
