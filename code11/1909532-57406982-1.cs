c#
using FluentAssertions;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
[SetUpFixture]
public class MySetUpClass
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        AssertionOptions.AssertEquivalencyUsing(e => e.Using(new MyNamespace.MyClassSelectionRule()));
    }
}
namespace MyNamespace
{
    class MyOuterClass
    {
        public MyInnerClass MemberToInclude { get; set; }
        public int MemberToExclude { get; set; }
    }
    class MyInnerClass
    {
        public int AnotherMemberToInclude { get; set; }
        public int MemberToExclude { get; set; }
    }
    internal class MyClassSelectionRule : IMemberSelectionRule
    {
        public bool IncludesMembers => false;
        public IEnumerable<SelectedMemberInfo> SelectMembers(IEnumerable<SelectedMemberInfo> selectedMembers, IMemberInfo context, IEquivalencyAssertionOptions config) =>
            selectedMembers.Where(e => !(e.DeclaringType.Name == nameof(MyOuterClass) && e.Name == nameof(MyOuterClass.MemberToExclude)));
    }
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Ignore_the_member_MemberToExclude_on_MyOuterClass()
        {
            var subject = new MyOuterClass
            {
                MemberToInclude = new MyInnerClass
                {
                    AnotherMemberToInclude = 42,
                    MemberToExclude = 42
                },
                MemberToExclude = 1
            };
            var expectation = new MyOuterClass
            {
                MemberToInclude = new MyInnerClass
                {
                    AnotherMemberToInclude = 42,
                    MemberToExclude = 42
                },
                MemberToExclude = 2
            };
            subject.Should().BeEquivalentTo(expectation);
        }
        [Test]
        public void Do_not_ignore_the_member_MemberToExclude_on_MyInnerClass()
        {
            var subject = new MyOuterClass
            {
                MemberToInclude = new MyInnerClass
                {
                    MemberToExclude = 1
                },
            };
            var expectation = new MyOuterClass
            {
                MemberToInclude = new MyInnerClass
                {
                    MemberToExclude = 2
                },
            };
            Action act = () => subject.Should().BeEquivalentTo(expectation);
            act.Should().Throw<AssertionException>();
        }
    }
}
