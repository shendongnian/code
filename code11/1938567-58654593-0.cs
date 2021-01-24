   public static class ExtensionMethod
    {
        public static string[] CustomExtensionMethods(this string[] myData, int NoofSkip)
        {
            var newData = new List<string>();
            for (int i = 0; i < myData.Length; i++ )
            {
                newData.Add(myData[i]);
                i = i + NoofSkip;
            }
            return newData.ToArray();
        }
    }
    
Call Method:
var data = toys.CustomExtensionMethods(1);
**OutPut:**
 { "car", "halloween-toys", "transformer" };
