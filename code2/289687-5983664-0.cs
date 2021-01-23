    float b = (float)number / 100.0f;
    Parallel.ForEach(Partitioner.Create(0, length), 
    (range) =>
    {
       for (int i = range.Item1; i < range.Item2; i++)
       {
          image.DataArray[i] = 
              (ushort)(mUIHandler.image1.DataArray[i] + 
              (ushort)(b * (float)mUIHandler.image2.DataArray[i]));
       }
    });
    
