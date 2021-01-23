    public abstract class MachineShape
    {
        public abstract void ProcessLine();
    }
    MachineShape[] shapes = ...;
    foreach (var shape in shapes)
    {
        shape.ProcessLine();
    }
