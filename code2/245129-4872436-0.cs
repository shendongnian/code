//in assembly G
public abstract class HumanFactory<T>
{
    public abstract T CreateHuman();
}
//in assembly A
public class Adam { }
//in assembly A
public class AdamFactory : HumanFactory<Adam>
{
    public override Adam CreateHuman()
    {
        return new Adam();
    }
}
//in assembly G
public class God
{
    public T Create<T>(HumanFactory<T> factory)
    {
        return factory.CreateHuman();
    }
}
