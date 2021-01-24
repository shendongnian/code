public void Walk(Vector2D target)
{
    var distance = Position.Distance(target);
    var steps = 5;
    var stepX = distance.X / steps;
    var stepY = distance.Y / steps;
    bool positiveX = target.X > Position.X;
    bool positiveY = target.Y > Position.Y;
    for (var i = 0; i < steps; i++)
    {
        var position = Position.Clone();
        position.X = (positiveX ? 1 : -1) * stepX + position.X;
        position.Y = (positiveY ? 1 : -1) * stepY + position.Y;
        if (Map.IsWalkable(position))
        {
            Character.Move(position);
        }
    }
}
Here I chose 5 steps. Alternatively, you can choose a fixed distance to move on each step. Then you can use some trigonometry or proportions to calculate how far to move in the x and y directions to move the chosen distance in a straight line.
