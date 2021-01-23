      private static string RemoveDirtyCharsFromString(string in_string)
         {
            int index = 0;
            int removed = 0;
            byte[] in_array = Encoding.UTF8.GetBytes(in_string);
            
            foreach (byte element in in_array)
            {
               if ((element == ' ') ||
                   (element == '-') ||
                   (element == ':'))
               {
                  removed++;
               }
               else
               {
                  in_array[index] = element;
                  index++;
               }
            }
            
            Array.Resize<byte>(ref in_array, (in_array.Length - removed));
            return(System.Text.Encoding.UTF8.GetString(in_array, 0, in_array.Length));
         }
