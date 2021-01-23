       public static class MString
       {
          /// <summary>
          /// This method simply duplicates the String.Join() method that was introduced in .Net 4.0. So
          /// it can be used in C# projects targeting .Net 3.5 or earlier.
          /// </summary>
          /// <typeparam name="T">type of the object collection (typically string)</typeparam>
          /// <param name="separatorString">separator to be placed between the strings</param>
          /// <param name="valueObjects">collection of objects that can be converted to strings</param>
          /// <returns>string containing all of the objects converted to string with separator string in between</returns>
          public static string Join<T>(string separatorString, IEnumerable<T> valueObjects)
          {
             if (separatorString == null)
                separatorString = "";
    
             bool firstValue = true;
             StringBuilder stringBuilder = new StringBuilder();
             foreach (T oneObject in valueObjects)
             {
                if (!firstValue)
                   stringBuilder.Append(separatorString);
                firstValue = false;
    
                stringBuilder.Append(oneObject == null ? "" : oneObject.ToString());
             }
    
             return stringBuilder.ToString();
          }
       }
