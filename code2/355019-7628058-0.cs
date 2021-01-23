    private static String GetNext<T>(String colorName) where T : struct
    {
         // Verify that T is actually an enum type
         if (!typeof(T).IsEnum)
            throw new ArgumentException("Type argument must be an enum type");
         T colorValue;
         String colorNameOut = String.Empty;
         if (Enum.TryParse<T>(colorName, out colorValue))
         {
            T initial = colorValue, next = colorValue;
            for (int i = (Convert.ToInt32(initial)) + 1; i < 10; i++)
            {
               if (Enum.IsDefined(typeof(T), i))
               {
                  next = (T)Enum.ToObject(typeof(T), i);
                  break;
               }
               else
               {
                  next = (T)Enum.ToObject(typeof(T), 0);
               }
            }
            colorNameOut = next.ToString();
         }
         return colorNameOut;
    }
