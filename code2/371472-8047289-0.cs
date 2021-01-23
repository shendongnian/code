    public IEnumerable<string> Split(string str)
    {
       char [] chars = str.ToCharArray();
       for(int i = 1, last = 0; i < chars.Length; i++) {
          if(char.IsLetter(chars[i])) {
             yield return new string(chars, last, i - last);
             last = i;
          }
       }
    }
