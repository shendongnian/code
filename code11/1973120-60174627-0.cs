csharp
interface IAAA
{
    int AAA { get; }
}
interface IBBB
{
    int BBB { get; }
}
2. Make your `TestService` constructor accept instances of said interfaces:
csharp
public class TestService : ITestService
{
    public TestService(IAAA a, IBBB b)
    {
        this.aaa = a.AAA;
        this.bbb = b.BBB;
    }
}
3. Create implementations of said interfaces:
csharp
public class AAAImpl : IAAA
{
    public int AAA => return 42;
}
public class BBBImpl : IBBB
{
    public int BBB => return 1337;
}
4. Map the interfaces to their implementations in `ConfigureServices` in `Startup.cs`:
csharp
services.AddSingleton<IAAA, AAAImpl>();
services.AddSingleton<IBBB, BBBImpl>();
.NET Core's dependency injection will do the rest.
Just remember, *interfaces are the answer to everything* ;).
