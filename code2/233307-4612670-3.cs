    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class CustomClass : Dictionary<int, int> { }
    public class CacheItemInfo
    {
        public int Count { get; set; }
        public string Message { get; set; }
    }
    class Program {
        public static void Main() {
            var cii = new CacheItemInfo();
            var data = new CustomClass { { 1, 1 }, { 2, 2 }, { 3, 3 } };
            GetCacheCollectionValues(ref cii, data);
            Console.WriteLine(cii.Count); // expect 3
        }
        private static void GetCacheCollectionValues(ref CacheItemInfo item, object cacheItemValue)
        {
            try
            {
                ICollection col;
                IEnumerable enumerable;
                if (cacheItemValue == null)
                {
                    item.Count = -1;
                }
                else if ((col = cacheItemValue as ICollection) != null)
                {
                    item.Count = col.Count;
                }
                else if ((enumerable = cacheItemValue as IEnumerable) != null)
                {
                    int count = 0;
                    foreach (object val in enumerable) count++;
                    item.Count = count;
                }
                else
                {
                    item.Count = -1;
                }
            }
            catch (Exception ex)
            {
                item.Count = -1;
                item.Message = "Exception on 'Count':" + ex.Message;
            }
        }
    }
