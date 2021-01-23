    public class OnlyLinesWithNumbersFilter : FilterDefinition
    {
        public OnlyLinesWithNumbersFilter()
        {
            WithName("OnlyLinesWithNumbers");
            WithCondition("LineNumber IN (:LineNumbers)");
            AddParameter("LineNumbers", NHibernateUtil.Int32);
        }
    }
