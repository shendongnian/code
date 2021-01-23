     public static class MyFormatter
        {
            public static string ToFreeString(this decimal d)
            {
                return d == 0 ? "Free" : d.ToString("d");
            }
        }
