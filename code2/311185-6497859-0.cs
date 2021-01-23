    int __declspec(dllexport) __stdcall AllocateMemory(int *values, const unsigned int N)
    {
      int sum = 0;
      for(unsigned int i = 0; i < N; i++)  { 
        values[i] = i;    
        sum += values[i];
      }
    }
    [DllImport("Test.dll")]
    public static extern int AllocateMemory(int[] someValues, int N);
    ...
      int[] values = new int[10];
      int sum = AllocateMemory(values, values.Length);
