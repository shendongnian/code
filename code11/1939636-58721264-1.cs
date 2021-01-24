    Key (23832771) Value X:1 Y:2 Potential:999.99
    Key (44512918) Value X:1 Y:2 Potential:999.99
----
    public class PointIt
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public double ElectricalPotential { get; set; }
    
        public override string ToString()
            => $"X:{PositionX} Y:{PositionY} Potential:{ElectricalPotential}";
    }
