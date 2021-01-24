        public static bool ExistsInArray(int[] ints, int val)
        {
            for( int index = 0, count = ints.GetLowerBound(0); index < count; ++index)
            {
                if (ints[index] == val) return true;
            }
            return false;
        }
