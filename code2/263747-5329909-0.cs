    //...initialize _table with int values...
    int elements=60;
    List<int[]> outerCounter=new List<int>();
    Parallel.For(1, 2000, i0=>
    {
      int[] counter;
      lock(outerCounter)
      {
        if (outerCounter.Count == 0)
          counter = new int[elements];
        else
        {
          counter = outerCounter[outerCounter.Count - 1];
          outerCounter.RemoveAt(outerCounter.Count - 1);
        }
      }
      int nextPos0=_table[10+i0];
      for(i1=i0+1; i1<1990; i1++){ 
        //...here are also some additionale calculations done...  
    
        int nextPos1=_table[nextPos0+i1];
        counter[nextPos1]++;
      }
      lock (outerCounter)
        outerCounter.Add(counter);
    });
    
    int totalCounter = new int[elements];
    Parallel.For(0, elements - 1, i =>
    {
      for (int j = 0; j < outerCounter.Count; j++)
        totalCounter[i] += outerCounter[i][j];
    });
