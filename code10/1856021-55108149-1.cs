var c = new Component();
c.Shape = new Shape();
c.UpdateShapes(s => {
    s.Height = 100;
    s.Width = 100;
    s.X = 5;
});
public class Component
{
    public IShape Shape { get; set; }
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public void UpdateShapes(Action<Component> update)
    {
        update(this);
        SyncronizeShapes();
    }
    public void SyncronizeShapes()
    {
        if (Shape != null)
        {
            Shape.Name = Name;
            Shape.Width = Width;
            Shape.Height = Height;
            Shape.X = X;
            Shape.Y = Y;
        }
    }
}
