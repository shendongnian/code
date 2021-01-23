    public abstract class MachineShape
    {
        public abstract void ProcessLine();
    }
    public class MachineLine : MachineShape
    {
        public override void ProcessLine()
        {
            // implement for MachineLine
        }
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        public double Thickness;
    }
    public class MachineCircle : MachineShape
    {
        public override void ProcessLine()
        {
            // implement for MachineCircle
        }
        public double CenterX;
        public double CenterY;
        public double Radius;
    }
    MachineShape[] shapes = ...;
    foreach (var shape in shapes)
    {
        shape.ProcessLine();
    }
