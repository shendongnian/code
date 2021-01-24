        // Let's class be partial one: if you want to add a method it it
        // you don't have to modify this code but 
        // add a chunk public partial static class MyStringRoutine {...}
        public partial static class MyStringRoutine {
          public static bool IsPalindrome(string text) {
            //DONE: do not forget about special cases
            if (string.IsNullOrEmpty(text))
              return true;
            for (int i = 0; i < text.Length / 2; ++i)
              if (text[i] != text[text.Length - 1 - i])
                return false;
            return true;
          }
        }
