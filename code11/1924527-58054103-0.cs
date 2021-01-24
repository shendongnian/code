        public static T NthElement<T>(List<T> list, int startIndex, int nthSmallest, int endIndex)
        {
            List<T> sublist = list.GetRange(startIndex, endIndex - startIndex);
            sublist.Sort();
            return sublist[nthSmallest - 1];
        }
