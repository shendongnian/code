    public class TestAssertions : ReferenceTypeAssertions<BaseTest, TestAssertions>
    {
        public TestAssertions(BaseTest instance) => Subject = instance;
        protected override string Identifier => "TestAssertion";
        [CustomAssertion]
        public AndConstraint<TestAssertions> BeWorking(string because = "", params object[] becauseArgs)
        {
            foreach (int num in Subject.TestList)
            {
                num.Should().BeGreaterThan(0, because, becauseArgs);
            }
            return new AndConstraint<TestAssertions>(this);
        }
    }
