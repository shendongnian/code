        static void foo(Type typeEnum)
        {
            if (typeEnum.IsEnum)
            {
                var array = Enum.GetValues(typeEnum)
                int[] arrayAsInts = array as int[];
                if(arrayAsInts != null)
                { 
                  foreach (var enumVal in arrayAsInts)
                  {
                     var _val = enumVal;                      
                  }
                }
                else
                {
                  foreach (var enumVal in array)
                  {
                     var _val = Convert.ChangeType(enumVal,typeof(int));                      
                  }
                }
            }
        }
