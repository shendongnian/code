      public static class Constants
      {
          private static string s_SampleString = "";
          public static string sampleString {
            get {return s_SampleString;}
            set {s_SampleString = value ?? "";}
          }
          // Manipulate with me, but not reassign
          public static readonly List<int> sampleList = new List<int> {1,2,3}; 
      }
