    [TestClass]
    public class SomeTest : TestBase
    {
        [TestMethod]
        public void Ensure_Something_Meets_Some_Condition()
        {
           // Arrange.
           DataTable dt = new DataTable("results");
           
           // Act.
           AddMockDataRow(dt);
    
           // Assert.
           Assert.IsTrue(someCondition);
        }
    }
