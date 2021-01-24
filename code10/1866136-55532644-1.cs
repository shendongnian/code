    [Test("List", "", true)]
    public object Test1(int[] input, int scale)
    {
       for (int i = 0; i < input.Length; i++)
       {
          foreach (int item in _array)
          {
             if (collectionSize - 1 == item)
             {
                break;
             }
          }
       }
    
       return null;
    }
    
    [Test("Dictionary", "", false)]
    public object Test2(int[] input, int scale)
    {
       for (int i = 0; i < input.Length; i++)
       {
          var s = _dictionary[input[i]];
       }
    
       return null;
    }
