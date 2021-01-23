      public string[] strings = new string[5];
      public void TestOne()
      {
         foreach (string s in strings)
         {
            string t = s;
         }
      }
      public void TestTwo()
      {
         string t;
         foreach (string s in strings)
         {
            t = s;
         }
      }
