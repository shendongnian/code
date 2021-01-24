public interface IAreaContext
{
    Area[] GetAreas();
}
public class AreaRepository
{
    private IAreaContext _areaContext;
    protected BaseAreaRepository(IAreaContext areaContext)
    {
        _areaContext = areaContext;
    }
    public Area[] GetAll()
    {
        return _areaContext.GetAreas();
    }
}
Then you could define multiple implementations of `IAreaContext` and injext:
public class MyAreaContext : IAreaContext
{
    public Area[] GetAreas()
    {
        return //Load data from an other source
    }
}
public class MyOtherAreaContext : IAreaContext
{
    public Area[] GetAreas()
    {
        return //Load data from an other source
    }
}
Now when you have this setup  repository could be easily testable for different behaviors of the context itself. This is just an example to demonstrate idea:
//Arrange
var context = new Mock<IAreaContext>();
context.Setup(m => m.GetAreas()).Verifiable();
var sut = new AreaRepository(context.Object);
//Act
var _ = sut.GetAll();
//Assert
context.Verify();
