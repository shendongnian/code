csharp
[PSerializable]
[MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
[AttributeUsage(AttributeTargets.Method)]
public class NotNullAttribute : MethodInterceptionAspect
{
    public override void OnInvoke(MethodInterceptionArgs args)
    {
        throw new NullReferenceException();
    }
}
And how it's used:
csharp
public interface IMyInterface {
    [NotNull(AttributeInheritance = MulticastInheritance.Multicast)]
    void DoSomething();
}
public class MyClass: IMyInterface {
    public void DoSomething() {
        // do something
    }
}
