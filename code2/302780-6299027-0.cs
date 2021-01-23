    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int length = 10;
            var j = 0;
            List<Dictionary<string, object>> theList = new List<Dictionary<string, object>>();
            for (int i = length - 1; i >= 0; i--)
            {
                var theDictionary = new Dictionary<string, object>();
                theDictionary.Add("string-" + i + "-" + j++, new object());
                theDictionary.Add("string-" + i + "-" + j++, new object());
                theDictionary.Add("string-" + i + "-" + j++, new object());
                theDictionary.Add("string-" + i + "-" + j++, new object());
                theList.Add(theDictionary);
            }
            var theTested = new CodeToTest(theList);
            var returnedValue = theTested.TestThis();
            Assert.AreEqual(returnedValue,length);
        }
    }
    class CodeToTest
    {
        private List<Dictionary<string, object>> listOfDictionaries;
        public CodeToTest(List<Dictionary<string, object>> listOfDictionaries)
        {
            this.listOfDictionaries = listOfDictionaries;
        }
        public int TestThis()
        {
            var i = 0;
            foreach (Dictionary<string, object> dictionary in listOfDictionaries)
            {
                i++;
                if (object.Equals(dictionary, listOfDictionaries.Last()))
                {
                    Console.WriteLine("Got here: " + i);
                    return i;
                }
            }
            return 0;
        }
    }
