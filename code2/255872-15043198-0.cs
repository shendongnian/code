    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Permute
    {
        public static bool Next(IList<IComparable> list)
        {
            int k = FindSmallestK(list);
            if (k < 0) return false;
            int l = FindLargestL(list, k);
            Swap(list, k, l);
            Reverse(list, k + 1);
            return true;
        }
        private static void Reverse(IList<IComparable> list, int p)
        {
            for (int i = p, j = list.Count - 1; i < j; i++, j--)
            {
                Swap(list, i, j);
            }
        }
        private static void Swap(IList<IComparable> list, int k, int l)
        {
            IComparable temp = list[k];
            list[k] = list[l];
            list[l] = temp;
        }
        private static int FindLargestL(IList<IComparable> list, int k)
        {
            for (int i = list.Count - 1; i > k; i--)
            {
                if (list[k].CompareTo(list[i]) < 0) return i;
            }
            return -1;
        }
        private static int FindSmallestK(IList<IComparable> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].CompareTo(list[i + 1]) < 0) return i;
            }
            return -1;
        }
    }
