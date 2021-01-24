c#
class MyClass
{
    public int MemberToInclude { get; set; }
    public int MemberToExclude { get; set; }
}
internal class MyClassSelectionRule : IMemberSelectionRule
{
    public bool IncludesMembers => false;
    public IEnumerable<SelectedMemberInfo> SelectMembers(IEnumerable<SelectedMemberInfo> selectedMembers, IMemberInfo context, IEquivalencyAssertionOptions config) =>
        selectedMembers.Where(e => e.Name != nameof(MyClass.MemberToExclude));
}
[TestClass]
public class UnitTest1
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        AssertionOptions.AssertEquivalencyUsing(e => e.Using(new MyClassSelectionRule()));
    }
    [TestMethod]
    public void TestMethod1()
    {
        var subject = new MyClass
        {
            MemberToInclude = 42,
            MemberToExclude = 1
        };
        var expectation = new MyClass
        {
            MemberToInclude = 42,
            MemberToExclude = 2
        };
        subject.Should().BeEquivalentTo(expectation);
    }
}
