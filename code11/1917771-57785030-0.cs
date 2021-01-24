      using System.Linq;
      ...
      string string1 = "a1/type/xyz/parts";
      string string2 = "a1/type/abcd/parts";
      bool result = string1
        .Split('/')                    // string1 parts
        .Where((v, i) => i != 2)       // all except 3d one
        .SequenceEqual(string2         // must be equal to 
           .Split('/')                 // string2 parts 
           .Where((v, i) => i != 2));  // all except 3d one
