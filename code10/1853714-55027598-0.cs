charp
public abstract class AbstractTest<TModel> where TModel : class
{
   public IRepository<TModel> repo;
   [Theory]
   [MemberData("InsertData")]
   public virtual void AbsTestInsert(TModel model)
   {
       try
       {
           repo.AddUpdate(model);
           Assert.True(true);
       }
       catch (Exception ex)
       {
           Assert.True(false, ex.Message);
       }
   }
}
public class TestClass : AbstractTest<TestModel>
{
    public static IEnumerable<object[]> InsertData;
    public TestClass()
    {
        repo = TestRepository();
    }
}
You define the data using the same name on each implementing class. It's not virtual/abstract, it's just lining things up by name.
