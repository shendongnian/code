    public interface IMyInterface
    {
       void Somemethod();
    }
    IMyInterface x = anyObject as IMyInterface;
    if( x != null )
    {
       x.Somemethod();
    }
