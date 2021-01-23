    void blah(IDictionary<int,int> dict)
    {
      for (int i=0; i<10; i++)
      {
        if ((i & 11) != 0)
        {
            int j;
            dict.TryGetValue(i, out j);
            System.Diagnostics.Debug.Print("{0}",j);
            j++;
        }
      }
    }
