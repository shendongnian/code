    public static void Permute(string[] strings, int start, int finish)
      {
        if (start == finish)
        {
          for (int i = 0; i <= finish; ++i)
          {
            Console.Write(strings[i] + " " );
          }
            Console.WriteLine("");
        }
        else
        {
          for (int i = start; i <= finish; ++i)
          {
            string temp = strings[start];
            strings[start] = strings[i];
            strings[i] = temp;
    
            Permute(strings, start+1, finish);
    
            temp = strings[start];
            strings[start] = strings[i];
            strings[i] = temp;
          }
        }
    
      }  // Permute()
