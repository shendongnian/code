    [TestFixture]
    public class TestCaseSample 
    {      
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GetProductById(int productId)
        {           
            Assert.That(pm.GetProductById(productId),Is.Not.Null);
        } 
    } 
