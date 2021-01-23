    for (int i = infData.Count - 1; i > 0 ; i--)
    {
      if(infData[i].Id==0)
      {
        infData.RemoveAt(i);
      }
    }
