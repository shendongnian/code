        public static IEnumerable<T> RandomPermutation<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable.Count() < 1)
                throw new InvalidOperationException("Must have some elements yo");
            Random random = new Random(DateTime.Now.Millisecond);
            while (enumerable.Any())
            {
                int currentCount = enumerable.Count();
                int randomIndex = random.Next(0, currentCount);
                yield return enumerable.ElementAt(randomIndex);
                if (randomIndex == 0)
                    enumerable = enumerable.Skip(1);
                else if (randomIndex + 1 == currentCount)
                    enumerable = enumerable.Take(currentCount - 1);
                else
                {
                    T removeditem = enumerable.ElementAt(randomIndex);
                    enumerable = enumerable.Where(item => !item.Equals(removeditem));
                }
            }
        }
