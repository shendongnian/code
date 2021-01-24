     public static string MoveChar(this string text, int oldIndex, int newIndex)
        {
            try
            {
                var chars = new List<Char>( text.ToCharArray(0, text.Length));
                var value = chars[oldIndex];
                chars.RemoveAt(oldIndex);
                chars.Insert(newIndex,value);
                return new string(chars.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
