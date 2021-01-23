    public static IEnumerable<int> IndicesOf(this string text, char value, int count)
            {
                var tokens = text.Split(value);
                var sum = tokens[0].Length;
                var currentCount = 0;
                for (int i = 1; i < tokens.Length && 
                                sum < text.Length && 
                                currentCount < count; i++)
                {
                    yield return sum;
                    sum += 1 + tokens[i].Length;
                    currentCount++;
                }
            }
