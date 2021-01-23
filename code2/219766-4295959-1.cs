    public class NodeMatrix
    {
        
        public NodeMatrix Right { get; set;}
        public NodeMatrix Left { get; set; }
        public NodeMatrix Up { get; set; }
        public NodeMatrix Down { get; set; }
        public int I  { get; set; }
        public int J  { get; set; }
        public double Data { get; set; }
        public NodeMatrix(int I, int J, double Data)
        {
            this.I = I;
            this.J = J;
            this.Data = Data;
        }
    }
    List<NodeMatrix> list = new List<NodeMatrix>(10000);
