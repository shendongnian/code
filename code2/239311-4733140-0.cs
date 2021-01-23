    [TestFixture]
    class MyTest {
      CultureInfo savedCulture;
      [SetUp]
      public void SetUp() {
        savedCulture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      }
      [TearDown]
      public void TearDown() {
        Thread.CurrentThread.CurrentCulture = savedCulture;
      }
    }
