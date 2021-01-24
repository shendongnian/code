public class Phit
{
  public List<Point> HitBoxes { get; private set; }
  public Phit(List<Point> hitboxes)
  {
    HitBoxes = hitboxes;
  }
}
Initialize your class with the hitboxes.
List<Point> hitboxes = new List<Point>
{
    new Point(1.2, 1.5),
    new Point(1.2, 3.0),
    new Point(1.2, 4.5)
};
Phit phit = new Phit(hitboxes);
The loop inside your MouseMove method.
foreach(Point p in phit.HitBoxes)
{
    if (e.X > p.X && e.X < p.X + hitw && e.Y > p.Y && e.Y < p.Y + hitw)
    {
        hitbox(c, p.X, p.Y, 8);
        h = true;
        tb.Text = p.Type;
        hitok = p;
    }
}    
