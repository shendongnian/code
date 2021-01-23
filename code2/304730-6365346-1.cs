    [Binding]
    public class FizzBuzzSteps
    {
        private int _min;
        private int _max;
        private string[] _results;
        [Given(@"I have a range of numbers from (\d+) to (\d+)")]
        public void GivenIHaveARangeOfNumbers(int min, int max)
        {
            _min = min;
            _max = max;
        }
        [When(@"I press Submit")]
        public void WhenIPressSubmit()
        {
            _results = FizzBuzz.Replace(_min, _max);
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            for (var i = 0; i < table.RowCount; i++)
            {
                var expected = table.Rows[i]["Numbers"];
                var actual = _results[i];
                Assert.AreEqual(expected, actual);
            }
        }
    }
