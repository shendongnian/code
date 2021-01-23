        public class WhereCondition
        {
        }
        public class WhereAndCondition : WhereCondition
        {
        }
        public class blah
        {
            public static void Blah()
            {
                List<WhereAndCondition> whereAnd = new List<WhereAndCondition>();
                MultiWhereToString(whereAnd);
            }
            public static string MultiWhereToString(List<WhereCondition> whereConditions)
            {
                return null;
            }
        }
