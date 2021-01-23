interface IMyReadableInterface
{
    int property { get; }
}
interface IMyFullInterface : IMyReadableInterface
{
    new int property { get; set; }
}
