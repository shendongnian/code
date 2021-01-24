        public static bool isConsecutive(int[] list)
        {
            for (var index = 0; index < list.Length; index++)
            {
                int nextIndex = index + 1;
                if (nextIndex >= list.Length) 
                    continue;
                int diff = list[nextIndex] - list[index];
                if (diff != 1 && diff != -1)
                {
                    return false;
                }
            }
            return true;
        }
