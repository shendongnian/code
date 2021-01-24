        string Subject_Code = "";
        string Subject_Name = "";
      public static bool check(string Subject_Code,Subject_Name) { 
            return (Subject_Code && Subject_Name == null || Subject_Code && Subject_Name== String.Empty) ? true : false; 
      } 
