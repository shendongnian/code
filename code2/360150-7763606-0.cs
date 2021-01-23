    [TestFixture]
    public class MyTestFixture
    {
      [Test]
      public void WordCounter([TextData(ResourcePath = "Data.txt")] string text)
      {
          var wordCounter = new WordCounter(text);
          int count = wordCounter.Count("Firecrest");
          Assert.AreEqual(4, count); // Should not include the plural form "Firecrests".
      }
    }
