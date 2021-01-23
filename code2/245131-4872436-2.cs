//in assembly G
public abstract class HumanFactory&lt;T&gt;
{
    public abstract T CreateHuman();
}
//in assembly A
public class Adam { }
//in assembly A
public class AdamFactory : HumanFactory&lt;Adam&gt;
{
    public override Adam CreateHuman()
    {
        return new Adam();
    }
}
//in assembly G
public class God
{
    public T Create&lt;T&gt;(HumanFactory&lt;T&gt; factory)
    {
        return factory.CreateHuman();
    }
}
