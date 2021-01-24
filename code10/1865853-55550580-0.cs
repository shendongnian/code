c#
[TestMethod]
public void Test()
{
    subject.Should().BeEquivalentTo(expected, 
        opt => opt.ComparingByMembers<DataStruct>());
}
Globally in e.g. `[AssemblyInitialize]`:
c#
[AssemblyInitialize]
public static void AssemblyInitialize(TestContext context)
{
    AssertionOptions.AssertEquivalencyUsing(opt => opt.ComparingByMembers<DataStruct>());
}
