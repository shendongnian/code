    public class BaseTest 
    {
    [SetUp] 
    public void SetUp()
    { 
        //Do generic Stuff 
    }
    [TearDown] 
    public void TearDown()
    {
      // Do generic stuff 
    }
    [TestFixture]
    public class TestClass : BaseTest
    {
     [SetUp] 
    public void SetUp()
    { 
        //Do Stuff 
    }
    [TearDown] 
    public void TearDown()
    {
      // Do stuff 
    }
