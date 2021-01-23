      public static class ObjectComparerUtility
      {
        public static bool ObjectsAreEqual<T>(T obj1, T obj2)
        {
          var obj1Serialized = JsonConvert.SerializeObject(obj1);
          var obj2Serialized = JsonConvert.SerializeObject(obj2);
    
          return CalculateHash(obj1Serialized) == CalculateHash(obj2Serialized);
        }
    
        private static ulong CalculateHash(string read)
        {
          ulong hashedValue = 3074457345618258791ul;
          for (int i = 0; i < read.Length; i++)
          {
            hashedValue += read[i];
            hashedValue *= 3074457345618258799ul;
          }
          return hashedValue;
        }
    
      }
