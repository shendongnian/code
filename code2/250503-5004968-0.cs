    [TestFixture]
    public class RowTestSample
    {
    	 [RowTest]
    	 [Row( 1)]
    	 [Row( 2)]
         [Row( 3)]
         [Row( 4)]
         [Row( 5)]
         [Row( 6)]
    	 public void GetProductById(int productId)
    	 {
    	      Assert.That(pm.GetProductById(productId),Is.Not.Null);
    	 }
    }
