public class Moving
{
    public bool StartedMoving { get; set; } = false;
    public void Move()
    {
        StartedMoving = true;
    }
}
Moving example = new Moving();
if (!example.StartedMoving)
{
    example.Move();
}
Also concider checking [Abstraction][1], it could be a good practice for what you're trying to achieve.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
