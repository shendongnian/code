        private static bool isConsecutive(int[] list)
        {
            switch (list.Length)
            {
                case 0:
                    throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
                case 1:
                    throw new ArgumentException("This collection contains only one element.", nameof(list));
            }
            int direction = list[1]-list[0];
            for (var index = 0; index < list.Length; index++)
            {
                int nextIndex = index + 1;
                if (nextIndex >= list.Length)
                {
                    continue;
                }
                int diff = list[nextIndex] - list[index];
                if (diff != direction)
                {
                    return false;
                }
            }
            return true;
        }
