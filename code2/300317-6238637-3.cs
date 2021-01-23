    public class MineNode : Node
    {
        public double FanPressure { get; set; }
    }
    public class MineTunnel : Edge<MineNode, MineNode>
    {
        public double Length { get; set; }
        public double CrossSectionArea { get; set; }
        public MineTunnel()
        {
            Source = new MineNode();
            Target = new MineNode();
        }
    }
