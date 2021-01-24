c#
var list1 = new[]
{
    new A
    {
        SomePropertyIDontCareAbout = "FOO",
        List = new[]
        {
            new B()
            {
                PropertyToInclude = "BAR",
                SomePropertyIDontCareAbout = "BAZ"
            },
        }
    },
};
var list2 = new[]
{
    new A
    {
        SomePropertyIDontCareAbout = "BOOM",
        List = new[]
        {
            new B()
            {
                PropertyToInclude = "BAR",
                SomePropertyIDontCareAbout = "BOOM"
            },
        }
    },
};
// Assert
list1.Should().BeEquivalentTo(list2, opt => opt
    .Including(e => e.List)
    .Excluding(e => e.SelectedMemberPath.EndsWith(nameof(B.SomePropertyIDontCareAbout))));
