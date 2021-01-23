    private static IEnumerable<int> FromZero(this int count)
        {
            if (count <= 0)
                yield break;
            for (var i = 0; i < count; i++)
            {
                yield return i;
            }
        }
        private static IEnumerable<int> FromOne(this int count)
        {
            if (count <= 0)
                yield break;
            for (var i = 1; i <= count; i++)
            {
                yield return i;
            }
        }
