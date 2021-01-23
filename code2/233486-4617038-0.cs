    public List<byte[]> GetSubArrays(byte[] array, byte delimeter)
    {
      if (array == null) throw new ArgumentNullException("array");
      List<byte[]> subArrays = new List<byte[]>();
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] == delimeter && i != array.Length - 1)
        {
          List<byte> subList = new List<byte>() { delimeter };
          
          for (int j = i+1; j < array.Length; j++)
          {
            subList.Add(array[j]);
            if (array[j] == delimeter)
            {
              subArrays.Add(subList.ToArray());
            }
          }
        }
      }
      return subArrays;
    }
