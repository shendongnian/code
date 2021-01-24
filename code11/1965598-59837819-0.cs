CSharp
public class Box
{
    public int Id { get; set; }
    public IEnumerable<Ball> Balls { get; set; }
}
public class Ball
{
    public int Id { get; set; }
    public int BoxId { get; set; }
    public Box Box { get; set; }
}
    var boxes = await Boxes
                // DO NOT Call Include(t => t.Balls) here!
                .Where(somecondition)
                .Select(t => new Box(){
                  Id = t.Id,
                  Balls = t.Balls.OrderByDescending(x => x.CreationTime)
                             .Take(1) // Only get what you need
                })               
                .ToListAsync()
Also when we use Select we can remove `.Include` because it won’t have any effect here.
