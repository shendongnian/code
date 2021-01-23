    Dictionary<string,int> dict=new Dictionary<string,int>();
    int counter=1;
    int IdOfString(string s)
    {
      int i;
      if(dict.TryGetValue(s,i))
        return i;
      else
      {
         i=counter;
         counter++;
         dict.Add(s,i);
         return i;
      }
    }
