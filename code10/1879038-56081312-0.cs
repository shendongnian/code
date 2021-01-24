    namespace LearnScan.LearnUser {
        public partial class NullableDateTime
        {
            public static implicit operator NullableDateTime(DateTime? dt)
            {
                if(dt.HasValue)
                {
                    return new NullableDateTime { IsNull = false, Value = dt.Value };
                }
                else
                {
                     return new NullableDateTime { IsNull = true };
                }
            }
        }
    }
