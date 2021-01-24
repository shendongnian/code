public abstract class MyBases<T> : IList<T>
{
    internal abstract List<T> Items { get; set; }
    public MyBase this[int index] { get => ((IList<MyBase>)Items)[index]; set => ((IList<MyBase>)Items)[index] = value; }
    // other implementations of IList...
}
public class MyConcretes : MyBases<MyConcrete>
{
    internal override List<MyConcrete> Items { get; set; }
}
