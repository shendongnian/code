        public static IEnumerable<char> GetEnumerator(this StringBuilder sb)
        {
            for (int i = 0; i < sb.Length; i++)
                yield return sb[i];
        }
