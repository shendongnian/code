    using System;
    using System.Collections.Generic;
    
    namespace SampleDataCache {
    
      public class SampleData {
        public string Name { get; set; }
      }
    
      public static class DataCache {
        private static readonly Dictionary<string, object> CacheDict
          = new Dictionary<string, object>();
    
        private static readonly object Locker = new object();
    
        public static T Get<T>(string key, Func<T> getSampleData) {
          if (!CacheDict.ContainsKey(key)) {
            lock (Locker)
              if (!CacheDict.ContainsKey(key)) {
                CacheDict.Add(key, getSampleData());
              }
          }
          return (T)CacheDict[key];
        }
      }
    
      public class Program {
        private static SampleData CreateSampleData() {
          return new SampleData() { Name = "Piotr Sowa" };
        }
    
        private static void Main(string[] args)
        {
          SampleData data = DataCache.Get("Author", CreateSampleData);
        }
      }
    }
