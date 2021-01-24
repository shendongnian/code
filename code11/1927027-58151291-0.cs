public class Phit
{
  public List<Point> Hits { get; private set; }
  public Phit(int numberOfHitBoxes)
  {
    Hits = new List<Point>(numberOfHitBoxes);
  }
}
Initialize your class with the number of hitboxes.
Phit phit = new Phit(42);
The loop inside your MouseMove method
foreach(Point p in phit.Hits)
{
    if (e.X > p.X && e.X < p.X + hitw && e.Y > p.Y && e.Y < p.Hit1.Y + hitw)
    {
        hitbox(c, p.X, p.Y, 8);
        h=true;
        tb.Text = p.Type;
        hitok = p;
    }
}    
