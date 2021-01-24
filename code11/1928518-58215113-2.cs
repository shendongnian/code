    private static String ProcessString(string text1, string text2) {
      return string.Concat(text2
        .Split('|')
        .Select((item, index) => item == "#" 
           ? text1[index].ToString() // substitute with corresponding char from text1
           : item));                 // keep as it is
    }
