    [TestFixture]
    public class DateValuesTest
    {
        [TestCaseSource(typeof(DateValuesTest), "DateValuesData")]
        public bool MonthIsDecember(DateTime date)
        {
            var month = date.Month;
            if (month == 12)
                return true;
            else
                return false;
        }
        private static IEnumerable DateValuesData()
        {
            yield return new TestCaseData(new DateTime(2010, 12, 5)).Returns(true);
            yield return new TestCaseData(new DateTime(2010, 12, 1)).Returns(true);
            yield return new TestCaseData(new DateTime(2010, 01, 01)).Returns(false);
            yield return new TestCaseData(new DateTime(2010, 11, 01)).Returns(false);
        }
    }
