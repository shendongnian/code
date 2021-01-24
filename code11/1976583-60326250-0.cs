        public static bool In<T>(this T t, params T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (t.Equals(array[i]))
                {
                    return true;
                }
            }
            return false;
        }
