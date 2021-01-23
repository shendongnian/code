        internal static int GetNumberOfQuarters(DateTime p_DtStart, DateTime p_DtEnd)
        {
            TimeSpan span = p_DtEnd.Subtract(p_DtStart);
            return (int)span.TotalDays % 90;
        }
