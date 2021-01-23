    public static class PermutationExtensions
    {
        /// <summary>
        /// Generates permutations.
        /// </summary>
        /// <typeparam name="T">Type of items to permute.</typeparam>
        /// <param name="items">Array of items. Will not be modified.</param>
        /// <returns>Permutations of input items.</returns>
        public static IEnumerable<T[]> Permute<T>(this T[] items)
        {
            T[] ApplyTransform(T[] values, (int First, int Second)[] tx)
            {
                var permutation = new T[values.Length];
                for (var i = 0; i < tx.Length; i++)
                    permutation[i] = values[tx[i].Second];
                return permutation;
            }
            void Swap<U>(ref U x, ref U y)
            {
                var tmp = x;
                x = y;
                y = tmp;
            }
            var length = items.Length;
            // Build identity transform
            var transform = new(int First, int Second)[length];
            for (var i = 0; i < length; i++)
                transform[i] = (i, i);
            yield return ApplyTransform(items, transform);
            while (true)
            {
                // Ref: E. W. Dijkstra, A Discipline of Programming, Prentice-Hall, 1997
                // Find the largest partition from the back that is in decreasing (non-increasing) order
                var decreasingpart = length - 2;
                while (decreasingpart >= 0 && transform[decreasingpart].First >= transform[decreasingpart + 1].First)
                    --decreasingpart;
                // The whole sequence is in decreasing order, finished
                if (decreasingpart < 0)
                    yield break;
                // Find the smallest element in the decreasing partition that is
                // greater than (or equal to) the item in front of the decreasing partition
                var greater = length - 1;
                while (greater > decreasingpart && transform[decreasingpart].First >= transform[greater].First)
                    greater--;
                // Swap the two
                Swap(ref transform[decreasingpart], ref transform[greater]);
                // Reverse the decreasing partition
                Array.Reverse(transform, decreasingpart + 1, length - decreasingpart - 1);
                yield return ApplyTransform(items, transform);
            }
        }
    }
