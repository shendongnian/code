public void Walk(Vector2D target)
{
    var distance = Position.Distance(target);
    bool positiveX = target.X > Position.X;
    bool positiveY = target.Y > Position.Y;
    for (var i = 0; i < distance.X; i++)
    {
        var position = Position.Clone();
        position.X = (positiveX ? 1 : -1) + position.X;
        position.Y = (positiveY ? 1 : -1) + position.Y;
        if (Map.IsWalkable(position))
        {
            Character.Move(position);
        }
    }
}
