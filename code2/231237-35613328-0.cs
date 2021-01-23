     public static IEnumerable<ulong> Generate(ulong n)
        {
            if (n < 1) yield break;
            yield return 1;
            ulong prev = 0;
            ulong next = 1;
            for (ulong i = 1; i < n; i++)
            {
                ulong sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
