     [TestClass]
      public class BaseTestClass
      {
       
        public virtual void Foo()
        {
          System.Windows.Forms.MessageBox.Show("Hello");
        }
      }
    
      [TestClass]
      public class TestClass : BaseTestClass
      {
         [TestInitialize]
        public override void Foo()
        {
          base.Foo();
        }
    
        [TestMethod]
        public void MyTestMethod()
        {
          Assert.IsTrue(true);
        }
      }
