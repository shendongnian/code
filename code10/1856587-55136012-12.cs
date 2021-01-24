      public static class Constants
      {
          public static string sampleString = "";
          public static List<int> sampleList = new List<int> {1,2,3};
      }
      ...
      Constants.sampleList = null;   // We can easly assign null
      ...
      Constants.sampleList.Add(123); // <- And have an unxpected exception
