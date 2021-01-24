        public static int CompareDiagnosticDetailsByValuesConsistently(DiagnosticDetails dd1, DiagnosticDetails dd2)
        {
            var maxDimension = Math.Max(dd1.Values.Count(), dd2.Values.Count());
            for (int i = 0; i < maxDimension; i++)
            {
                if (dd1.Values.ElementAtOrDefault(i)?.Value == null)
                {
                    if (dd2.Values.ElementAtOrDefault(i)?.Value == null)
                        continue;
                    return 1;
                }
                int result = dd1.Values.ElementAt(i).Value.CompareTo(dd2.Values.ElementAt(i).Value);
                if (result == 0)
                    continue;
                return result;
            }
            return 0;
        }
